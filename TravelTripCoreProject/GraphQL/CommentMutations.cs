using EntityGraphQL.Schema;
using System.Linq.Expressions;
using TravelTripCoreProject.Models.Classes;

namespace TravelTripCoreProject.GraphQL
{
    public class CommentMutations
    {
        [GraphQLMutation("Add a new comment to a blog")]
        public Expression<Func<Context, Comment>> AddComment(
            Context db,
            int blogId,
            string username,
            string email,
            string userComment
        )
        {
            var comment = new Comment
            {
                BlogId = blogId,
                Username = username,
                Email = email,
                UserComment = userComment,
            };

            db.Comments.Add(comment);
            db.SaveChanges();

            return ctx => ctx.Comments.First(c => c.Id == comment.Id);
        }
    }
}
