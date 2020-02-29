using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewsForums.Data;
using NewsForums.Data.Models;
using NewsForums.Models.Reply;

namespace NewsForums.Controllers
{
    public class ReplyController : Controller
    {
        private readonly IPost _postService;
        private readonly UserManager<ApplicationUser> _userManager;


        protected ReplyController(IPost postService)
        {
            _postService = postService;
        }


        public async Task<IActionResult> Create(int id)
        {
            var post = _postService.GetById(id);
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var model = new PostReplyModel
            {
                PostContent=post.Content,
                PostTitle=post.Title,
                PostId=post.Id,
                 
                AuthorName=User.Identity.Name,
                AuthorImageUrl=user.ProfileImageUrl,
                AuthorRating=user.Rating,
                IsAuthorAdmin=User.IsInRole("Admin"),

                ForumName=post.Forum.Title,
                ForumId=post.Forum.Id,
                ForumImageUrl=post.Forum.UrlImage,
                Created=DateTime.Now

            };

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddReply(PostReplyModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);

            var reply = BuildReply(model, user);

            await _postService.AddReply(reply);
            return RedirectToAction("Index", "Post", new { id = model.PostId });
        }

        private PostReply BuildReply(PostReplyModel model, ApplicationUser user)
        {
            var post = _postService.GetById(model.PostId);
            return new PostReply
            {
                Post=post,
                Content=model.ReplyContent,
                CreatedTime=DateTime.Now,
                User=user
            };
        }
    }
}