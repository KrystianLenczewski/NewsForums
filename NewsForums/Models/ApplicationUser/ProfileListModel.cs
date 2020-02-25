using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsForums.Models.ApplicationUser
{
    public class ProfileListModel
    {
        public IEnumerable<ProfileModel> Profiles { get; set; }
    }
}
