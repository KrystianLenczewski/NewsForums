﻿using NewsForums.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsForums.Data.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public DateTime CreatedTime { get; set; }
        public ApplicationUser User { get; set; }
        public Forum Forum { get; set; }

        public IEnumerable<PostReply> Replies { get; set; }

    }
}