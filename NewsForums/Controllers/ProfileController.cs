using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewsForums.Data;
using NewsForums.Data.Models;
using NewsForums.Models.ApplicationUser;

namespace NewsForums.Controllers
{
    public class ProfileController : Controller
    { 
   private readonly UserManager<ApplicationUser> _userManager;
    private readonly IApplicationUser _userService;
    private readonly IUpload _uploadService;
    

    public ProfileController(UserManager<ApplicationUser> userManager, IApplicationUser userService, IUpload uploadService)
    {
        _userManager = userManager;
        _userService = userService;
        _uploadService = uploadService;
        
    }

    [Authorize]
    public IActionResult Detail(string id)
    {
        var user = _userService.GetById(id);
        var userRoles = _userManager.GetRolesAsync(user).Result;

        var model = new ProfileModel()
        {
            UserId = user.Id,
            UserName = user.UserName,
            UserRating = user.Rating.ToString(),
            Email = user.Email,
            ProfileImageUrl = user.ProfileImageUrl,
            MemberSince = user.MemberSince,
            IsActive = user.IsActive,
            IsAdmin = userRoles.Contains("Admin")
        };

        return View(model);
    }

    /*
     * Files uploaded using the IFormFile technique are buffered in memory or on disk on the web server 
     * before being processed. Inside the action method, the IFormFile contents are accessible as a stream. 
     * In addition to the local file system, files can be streamed to Azure Blob storage or Entity Framework.
     */

   
    public IActionResult Index()
    {
        var profiles = _userService.GetAll()
            .OrderByDescending(user => user.Rating)
            .Select(u => new ProfileModel
            {
                Email = u.Email,
                UserName=u.UserName,
                ProfileImageUrl = u.ProfileImageUrl,
                UserRating = u.Rating.ToString(),
                MemberSince = u.MemberSince,
                IsActive = u.IsActive
            });

        var model = new ProfileListModel
        {
            Profiles = profiles
        };

        return View(model);
    }
        //public IActionResult Index()
        //{
        //    var profiles = _userService.GetAll()
        //        .OrderByDescending(user => user.Rating)
        //        .Select(u => new ProfileModel
        //        {
        //        Email=u.Email,
        //        UserName=u.UserName,
        //        UserRating=u.Rating.ToString(),
        //        MemberSince=u.MemberSince
        //        });
        //    var model = new ProfileListModel
        //    {
        //        Profiles = profiles
        //    };
        //    return View(model);
        //}
        
   
}
}