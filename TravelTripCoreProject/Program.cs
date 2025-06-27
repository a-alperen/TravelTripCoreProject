using Microsoft.EntityFrameworkCore;
using TravelTripCoreProject.Models.Classes;
using EntityGraphQL.AspNet;
using TravelTripCoreProject.Services;
using TravelTripCoreProject.GraphQL;
using EntityGraphQL.Schema;

namespace TravelTripCoreProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddHttpClient<GraphQLService>();
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession();
            builder.Services.AddAuthentication("CookieAuth")
                .AddCookie("CookieAuth", options =>
                {
                    options.LoginPath = "/Login/Login";
                });
            builder.Services.AddDbContext<Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            
            // ---- GRAPHQL SCHEMA ----
            builder.Services.AddGraphQLSchema<Context>(options =>
            {
                options.ConfigureSchema = (schema) =>
                {
                    schema.AddMutationsFrom<CommentMutations>();
                    schema.AddMutationsFrom<ContactMutations>();
                    schema.AddMutationsFrom<BlogMutations>();
                };
            }
            );
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            // ---- GRAPHQL ENDPOINT EKLE ----
            app.MapGraphQL<Context>();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Main}/{action=Index}/{id?}");

            app.Run();
        }

    }
}
