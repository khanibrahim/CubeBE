﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApplication1.Models
{


    public class UserRole : IdentityUserRole<long>
    {
    }

    public class UserClaim : IdentityUserClaim<long>
    {
    }

    public class UserLogin : IdentityUserLogin<long>
    {
    }


    public class Role : IdentityRole<long, UserRole>
    {
        public Role() { }
        public Role(string name) { Name = name; }
    }

    public class UserStore : UserStore<ApplicationUser, Role, long,
        UserLogin, UserRole, UserClaim>
    {
        public UserStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }

    public class RoleStore : RoleStore<Role, long, UserRole>
    {
        public RoleStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }



    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser<long, UserLogin, UserRole, UserClaim>
    {
        [Column(TypeName = "VARCHAR")]
        [StringLength(10)]
        public string GuestId { get; set; }

        public bool IsActive { get; set; }


        public DateTime RCT { get; set; }
        public DateTime RUT { get; set; }
        public long RCB { get; set; }
        public long RUB { get; set; }

        public string MobileNo { get; set; }

        public long PropertyId { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, long> manager, string authtype)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authtype);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, Role, long, UserLogin, UserRole, UserClaim>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ApplicationDbContext>());

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            string schema = "dbo";
            base.OnModelCreating(modelBuilder); // This needs to go before the other rules!

            modelBuilder.Entity<Role>().ToTable("Role", schema);
            modelBuilder.Entity<UserRole>().ToTable("UserRole", schema);
            modelBuilder.Entity<UserClaim>().ToTable("UserClaim", schema);
            modelBuilder.Entity<UserLogin>().ToTable("UserLogin", schema);
            modelBuilder.Entity<ApplicationUser>().ToTable("Userdetail", schema).Property(p => p.Id).HasColumnName("UserId");



        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //public System.Data.Entity.DbSet<Cube.Models.Question> Questions { get; set; }

        //public System.Data.Entity.DbSet<DL.SQL.QuestionPaper> questionpapers { get; set; }
    }


}