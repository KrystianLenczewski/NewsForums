using Microsoft.EntityFrameworkCore;
using NewsForums.Data;
using NewsForums.Service;
using NUnit.Framework;
using System;
using System.Linq;

namespace NewsForums.Tests
{
    [TestFixture]
   public class Search_Service_Should
    {

        [OneTimeSetUp]
        public void Set_Up_Test_Fixture()
        {

        }

        



        [TestCase("coffee",3)]
        [TestCase("teA",1)]
        [TestCase("water",0)]
        public void Return_Filtered_Results_Corresponding_To_Query(string query,int expected)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            using (var ctx = new ApplicationDbContext(options))
            {
                ctx.Forums.Add(new Data.Models.Forum
                { Id = 19 });
                ctx.Posts.Add(new Data.Models.Post
                {
                    Forum = ctx.Forums.Find(19),
                    Id = 23523,
                    Title = "First Post",
                    Content = "Coffee"
                });
                ctx.Posts.Add(new Data.Models.Post
                {
                    Forum = ctx.Forums.Find(19),
                    Id = -2523,
                    Title = "Coffee",
                    Content = "Some Content"
                });
                ctx.Posts.Add(new Data.Models.Post
                {
                    Forum = ctx.Forums.Find(19),
                    Id = 223,
                    Title = "Tea",
                    Content = "Coffee"
                });
                ctx.SaveChanges();
            }

            using (var ctx = new ApplicationDbContext(options))
            {
                var postService = new PostService(ctx);
                var result = postService.GetFilteredPosts(query);

                var postCount = result.Count();

                Assert.AreEqual(expected, postCount);
               
                

            }


        }
    }
}
