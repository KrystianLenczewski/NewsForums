using NewsForums.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsForums.Data
{
    public interface IPost
    {
        Post GetById(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetFilteredPosts(Forum forum,string search);

        Task Add(Post post);
        Task Delete(int id);
        Task EditPostContent(int id,string newContent);
        Task AddReply(PostReply reply);
        IEnumerable<Post> GetPostsByForum(int id);
        IEnumerable<Post> GetLatestPosts(int v);
    }
}
