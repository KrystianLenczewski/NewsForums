﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewsForums.Data.Models;


namespace NewsForums.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

       public DbSet<ApplicationUser> ApplicationUsers { get; set; }
       public DbSet<Forum> Forums { get; set; }
       public DbSet<Post> Posts { get; set; }
       public DbSet<PostReply> Replies { get; set; }
       
    }
}
