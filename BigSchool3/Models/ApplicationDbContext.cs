﻿using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

namespace BigSchool3.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
       public DbSet<Category> Categories { get; set; }
       public DbSet<Course> Courses { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
          
    }
}