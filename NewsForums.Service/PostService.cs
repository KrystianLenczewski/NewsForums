using NewsForums.Data;
using NewsForums.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsForums.Service
{
    public class PostService : IPost
    {
        private readonly ApplicationDbContext _context;
        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task Add(Post post)
        {
            throw new NotImplementedException();
        }

        public Task AddReply(PostReply reply)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditPostContent(int id, string newContent)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAll()
        {
            throw new NotImplementedException();
        }

        public Post GetById()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetFilteredPosts(string search)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetPostsByForum(int id)
        {
            return _context.Forums.Where(Forum => Forum.Id == id).First().Posts;

        }
    }
}
