using System;
using System.Collections.Generic;
using System.Text;

namespace NewsForums.Data.Models
{
    public class Forum
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UrlImage { get; set; }
        public DateTime CreatedTime { get; set; }

        //host a collection of posts 
        public IEnumerable<Post> Posts { get; set; }


    }
}
