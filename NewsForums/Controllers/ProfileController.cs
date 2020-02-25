using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewsForums.Data;
using NewsForums.Data.Models;

namespace NewsForums.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUser _userService;
        private readonly IUpload _uploadService;
        public ProfileController(UserManager<ApplicationUser>userManager,
           IApplicationUser userService )
        {
            _userManager = userManager;
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(string id)
        {
            
            return View();
        }
    }
}