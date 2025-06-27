using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using TravelTripCoreProject.Models.Classes;

namespace TravelTripCoreProject.Services
{
    public class GraphQLService(HttpClient httpClient)
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<Blog?> GetBlogByIdAsync(int blogId)
        {
            var query = new
            {
                query = @"query ($id: Int!) {
                    blog(id: $id) {
                        id
                        title
                        description
                        blogImage
                        comments {
                            id
                            username
                            userComment
                        }
                    }
                }",
                variables = new { id = blogId }
            };

            var json = JsonConvert.SerializeObject(query);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("http://localhost:5135/graphql", content);
            var result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"GraphQL Hatası: {result}");
            }

            var root = JsonConvert.DeserializeObject<GraphQLBlogResponse>(result);
            return root?.Data?.Blog;
        }
        public async Task<Comment?> AddCommentAsync(int blogId, string username, string email, string userComment)
        {
            var mutation = new
            {
                query = @"mutation ($blogId: Int!, $username: String!, $email: String!, $userComment: String!) {
                    addComment(
                        blogId: $blogId,
                        username: $username,
                        email: $email,
                        userComment: $userComment
                    ) {
                        id
                        username
                        email
                        userComment
                        blogId
                    }
                }",
                variables = new
                {
                    blogId,
                    username,
                    email,
                    userComment
                }
            };

            var json = JsonConvert.SerializeObject(mutation);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("http://localhost:5135/graphql", content);
            var result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception($"GraphQL Hatası: {result}");

            var root = JsonConvert.DeserializeObject<GraphQLAddCommentResponse>(result);
            return root?.Data?.AddComment;
        }
        public async Task<BlogOffsetPage> GetPagedBlogsAsync(int skip, int take)
        {
            var query = new
            {
                query = @"query ($skip: Int!, $take: Int!) {
                    blogs(skip: $skip, take: $take) {
                        items {
                            id
                            title
                            description
                            blogImage
                        }
                        totalItems
                        hasNextPage
                        hasPreviousPage
                    }
                }",
                variables = new { skip, take }
            };

            var json = JsonConvert.SerializeObject(query);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("http://localhost:5135/graphql", content);
            var result = await response.Content.ReadAsStringAsync();

            var root = JsonConvert.DeserializeObject<GraphQLPagedBlogsResponse>(result);
            return root?.data?.blogs ?? new BlogOffsetPage();
        }

        public async Task<Contact?> AddContactAsync(string name, string email, string message, string subject)
        {
            var mutation = new
            {
                query = @"mutation ($name: String!, $email: String!, $subject: String!, $message: String!) {
                addContact(
                    name: $name,
                    email: $email,
                    subject: $subject,
                    message: $message
                ) {
                    id
                    nameSurname
                    email
                    message
                    subject
                }
            }",
                variables = new { name, email, subject, message }
            };

            var json = JsonConvert.SerializeObject(mutation);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("http://localhost:5135/graphql", content);
            var result = await response.Content.ReadAsStringAsync();

            var root = JsonConvert.DeserializeObject<AddContactResponse>(result);
            return root?.data?.addContact;
        }
        public async Task<Blog?> AddBlogAsync(string title, string description, string blogImage, DateTime dateTime)
        {
            var mutation = new
            {
                query = @"mutation ($title: String!, $description: String!, $blogImage: String!, $dateTime: String!) {
                addBlog(
                    title: $title,
                    description: $description,
                    blogImage: $blogImage,
                    dateTime: $dateTime
                ) {
                    id
                    title
                    description
                    blogImage
                    dateTime
                }
            }",
                variables = new { title, description, blogImage, dateTime }
            };

            var json = JsonConvert.SerializeObject(mutation);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("http://localhost:5135/graphql", content);
            var result = await response.Content.ReadAsStringAsync();
            
            var root = JsonConvert.DeserializeObject<AddBlogResponse>(result);
            return root?.data?.addBlog;
        }
        public async Task<Blog?> UpdateBlogAsync(int id, string title, string description, string blogImage, DateTime dateTime)
        {
            var mutation = new
            {
                query = @"mutation ($id: Int!, $title: String!, $description: String!, $blogImage: String!, $dateTime: String!) {
                updateBlog(
                    id: $id,
                    title: $title,
                    description: $description,
                    blogImage: $blogImage,
                    dateTime: $dateTime
                ) {
                    id
                    title
                    description
                    blogImage
                    dateTime
                }
            }",
                variables = new { id, title, description, blogImage, dateTime }
            };

            var json = JsonConvert.SerializeObject(mutation);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("http://localhost:5135/graphql", content);
            var result = await response.Content.ReadAsStringAsync();

            var root = JsonConvert.DeserializeObject<UpdateBlogResponse>(result);
            return root?.data?.updateBlog;
        }

        public async Task<bool> DeleteBlogAsync(int id)
        {
            var mutation = new
            {
                query = @"mutation ($id: Int!) {
                deleteBlog(id: $id)
            }",
                variables = new { id }
            };

            var json = JsonConvert.SerializeObject(mutation);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("http://localhost:5135/graphql", content);
            var result = await response.Content.ReadAsStringAsync();
            // Parse et!
            var root = JsonConvert.DeserializeObject<DeleteBlogResponse>(result);
            return root?.data?.deleteBlog ?? false;
        }
    }

    public class GraphQLBlogResponse
    {
        public GraphQLBlogData? Data { get; set; }
    }

    public class GraphQLBlogData
    {
        public Blog? Blog { get; set; }
    }
    public class GraphQLAddCommentResponse
    {
        public AddCommentData? Data { get; set; }
    }
    public class AddCommentData
    {
        public Comment? AddComment { get; set; }
    }
    public class GraphQLBlogsResponse
    {
        public GraphQLBlogsData? Data { get; set; }
    }

    public class GraphQLBlogsData
    {
        public List<Blog>? Blogs { get; set; }
    }
    public class GraphQLPagedBlogsResponse
    {
        public GraphQLPagedBlogsData data { get; set; }
    }
    public class GraphQLPagedBlogsData
    {
        public BlogOffsetPage blogs { get; set; }
    }
    public class BlogOffsetPage
    {
        public List<Blog> items { get; set; }
        public int totalItems { get; set; }
        public bool hasNextPage { get; set; }
        public bool hasPreviousPage { get; set; }
    }
    public class AddContactResponse
    {
        public AddContactData data { get; set; }
    }
    public class AddContactData
    {
        public Contact addContact { get; set; }
    }
    public class AddBlogResponse
    {
        public AddBlogData data { get; set; }
    }
    public class AddBlogData
    {
        public Blog addBlog { get; set; }
    }
    public class UpdateBlogResponse
    {
        public UpdateBlogData data { get; set; }
    }
    public class UpdateBlogData
    {
        public Blog updateBlog { get; set; }
    }
    public class DeleteBlogResponse
    {
        public DeleteBlogData data { get; set; }
    }
    public class DeleteBlogData
    {
        public bool deleteBlog { get; set; }
    }
}
