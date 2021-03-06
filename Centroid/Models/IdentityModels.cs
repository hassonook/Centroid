﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Centroid.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Centroid.Models.Home> Homes { get; set; }

        public System.Data.Entity.DbSet<Centroid.Models.About> Abouts { get; set; }

        public System.Data.Entity.DbSet<Centroid.Models.Job> Jobs { get; set; }

        public System.Data.Entity.DbSet<Centroid.Models.ProfileDocument> ProfileDocuments { get; set; }

        public System.Data.Entity.DbSet<Centroid.Models.Service> Services { get; set; }

        public System.Data.Entity.DbSet<Centroid.Models.ServiceDetails> ServiceDetails { get; set; }

        public System.Data.Entity.DbSet<Centroid.Models.Project> Projects { get; set; }

        public System.Data.Entity.DbSet<Centroid.Models.QHSE> QHSEs { get; set; }

        public System.Data.Entity.DbSet<Centroid.Models.JobApplication> JobApplications { get; set; }

        public System.Data.Entity.DbSet<Centroid.Models.PersonalInfo> PersonalInfoes { get; set; }

        public System.Data.Entity.DbSet<Centroid.Models.Education> Educations { get; set; }

        public System.Data.Entity.DbSet<Centroid.Models.WorkExperience> WorkExperiences { get; set; }

        public System.Data.Entity.DbSet<Centroid.Models.ContactUs> ContactUs { get; set; }
        public System.Data.Entity.DbSet<Centroid.Models.Career> Careers { get; set; }
        public System.Data.Entity.DbSet<Centroid.Models.KeyRecord> KeyRecords { get; set; }


    }
}