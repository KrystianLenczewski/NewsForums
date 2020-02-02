using NewsForums.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsForums.Data.Models
{
    public class PostReply
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedTime { get; set; }
        public ApplicationUser User { get; set; }
        public Post Post { get; set; }
    }
}
