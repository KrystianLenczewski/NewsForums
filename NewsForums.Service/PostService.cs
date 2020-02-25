using Microsoft.EntityFrameworkCore;
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
        public async Task Add(Post post)
        {
            _context.Add(post);
            await _context.SaveChangesAsync();

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
            return _context.Posts
                 .Include(post => post.User)
                 .Include(post => post.Replies)
                   .ThenInclude(reply => reply.User)
                 .Include(post => post.Forum);
        }

        public Post GetById(int id)
        {
            return _context.Posts.Where(post => post.Id == id)
                 .Include(post => post.User)
                 .Include(post => post.Replies)
                   .ThenInclude(reply=>reply.User)
                 .Include(post => post.Forum)
                 .First();
        }

        public IEnumerable<Post> GetFilteredPosts(Forum forum,string searchQuery)
        {
            //var forum = _context.Forums.Find(id);
            return string.IsNullOrEmpty(searchQuery)?forum.Posts:
                forum.Posts.Where(post => post.Title.Contains(searchQuery) || post.Content.Contains(searchQuery));
        }
        public IEnumerable<Post> GetFilteredPosts( string searchQuery)
        {
            return GetAll().Where(post => post.Title.Contains(searchQuery)
            || post.Content.Contains(searchQuery));
        }
        public IEnumerable<Post> GetLatestPosts(int v)
        {
          return  GetAll().OrderByDescending(post => post.CreatedTime).Take(v);
        }

        public IEnumerable<Post> GetPostsByForum(int id)
        {
            return _context.Forums.Where(Forum => Forum.Id == id).First().Posts;

        }
    }
}
