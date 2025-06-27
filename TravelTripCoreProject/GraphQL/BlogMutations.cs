using EntityGraphQL.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;
using TravelTripCoreProject.Models.Classes;

namespace TravelTripCoreProject.GraphQL
{
    public class BlogMutations
    {
        [GraphQLMutation("Add a new blog")]
        public Expression<Func<Context, Blog>> AddBlog(
            Context db,
            string title,
            string description,
            string blogImage,
            string dateTime
        )
        {
            var blog = new Blog
            {
                Title = title,
                Description = description,
                BlogImage = blogImage,
                DateTime = DateTime.Parse(dateTime)
            };

            db.Blogs.Add(blog);
            db.SaveChanges();

            return ctx => ctx.Blogs.First(b => b.Id == blog.Id);
        }


        [GraphQLMutation("Update a blog")]
        public Expression<Func<Context, Blog>> UpdateBlog(
            Context db,
            int id,
            string title,
            string description,
            string blogImage,
            string dateTime
        )
        {
            var blog = db.Blogs.FirstOrDefault(b => b.Id == id) ?? throw new Exception("Blog not found");

            blog.Title = title;
            blog.Description = description;
            blog.BlogImage = blogImage;
            blog.DateTime = DateTime.Parse(dateTime);

            db.SaveChanges();

            return ctx => ctx.Blogs.First(b => b.Id == id);
        }

        [GraphQLMutation]
        public async Task<bool> DeleteBlog(int id, [FromServices] Context db)
        {
            var blog = await db.Blogs.FindAsync(id);
            if (blog == null)
                return false;

            db.Blogs.Remove(blog);
            await db.SaveChangesAsync();
            return true;
        }
    }
}
