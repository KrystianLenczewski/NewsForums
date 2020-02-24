﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NewsForums.Data;
using NewsForums.Data.Models;
using NewsForums.Models.Forum;
using NewsForums.Models.Post;

namespace NewsForums.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForum _forumService;
        private readonly IPost _postService;

        public ForumController(IForum forumService,IPost postService)
        {
            _forumService = forumService;
            _postService = postService;
        }
        public IActionResult Index()
        {

            var forums = _forumService.GetAll().Select(forum=>new ForumListingModel{
               Id=forum.Id,
                Name=forum.Title,
                Description=forum.Description

            });
            var model = new ForumIndexModel
            {
                
ForumList = forums
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Search(int id,string searchQuery)
        {
            return RedirectToAction("Topic", new { id, searchQuery });
        }
        public IActionResult Topic(int id,string searchQuery)
        {
            var forum = _forumService.GetById(id);
            var posts=new List<Post>();
           
                 posts = _postService.GetFilteredPosts(forum, searchQuery).ToList();
          
            

            var postListings = posts.Select(post => new PostListingModel
            {
                Id=post.Id,
                AuthorId=post.User.Id,
                AuthorName=post.User.UserName,
                AuthorRating=post.User.Rating,
                Title=post.Title,
                DatePosted=post.CreatedTime.ToString(),
                RepliesCount=post.Replies.Count(),
                Forum=BuildForumListing(post)

            });
            var model = new ForumTopicModel
            {
                Posts = postListings,
                Forum = BuildForumListing(forum)
            };
            return View(model);

        }

        private ForumListingModel BuildForumListing(Post post)
        {
            var forum = post.Forum;
            return BuildForumListing(forum);
        }
        private ForumListingModel BuildForumListing(Forum forum)
        {
            
            return new ForumListingModel
            {
                Id = forum.Id,
                Name = forum.Title,
                Description = forum.Description,
                ImageUrl = forum.UrlImage
            };
        }
    }
}