using NewsForums.Data.Models;
using NewsForums.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsForums.Data
{
    public interface IForum
    {
        Forum GetById(int id);
        IEnumerable<Forum> GetAll();
        IEnumerable<ApplicationUser> GetAllUsers();

        Task Create(Forum forum);
        Task Delete(int forumId);
        Task UpdateForumTitle(int forumId, string newTitle);
        Task UpdateForumDescription(int forumId, string newDescription);

    }
}
