using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsForums.Data;
using NewsForums.Data.Models;
using NewsForums.Models.Post;
using NewsForums.Models.Reply;

namespace NewsForums.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _postService;
        public PostController(IPost postService)
        {
            _postService = postService;
        }
        public IActionResult Index(int id)
        {
            var post = _postService.GetById(id);

            var replies = BuildPostReplies(post.Replies);
            var model = new PostIndexModel
            {
                Id=post.Id,
                Title=post.Title,
                AuthorId=post.User.Id,
                AuthorName=post.User.UserName,
                AuthorImageUrl=post.User.ProfileImageUrl,
                AuthorRating=post.User.Rating,
                Created=post.CreatedTime,
                PostContent=post.Content,
                Replies=replies
            };
            return View(model);
        }

        private IEnumerable<PostReplyModel> BuildPostReplies(IEnumerable<PostReply> replies)
        {

            return replies.Select(reply => new PostReplyModel
            {
                Id = reply.Id,
                AuthorName = reply.User.UserName,
                AuthorId = reply.User.ProfileImageUrl,
                AuthorRating = reply.User.Rating,
                Created = reply.CreatedTime,
                ReplyContent = reply.Content

            });
     
        }
    }
}