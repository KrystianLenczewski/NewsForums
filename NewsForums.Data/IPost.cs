using NewsForums.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsForums.Data
{
    public interface IPost
    {
        Post GetById();
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetAll();


    }
}
