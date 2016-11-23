using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BCMS.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        [MinLength(2)]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [MinLength(2)]
        public string LastName { get; set; }

        //[Required(ErrorMessage = "Please Enter Your Email")]
        //[RegularExpression(@"^[a-zA-Z0-9]+@[a-zA-Z]+\.[a-zA-Z]{2,4}$", ErrorMessage = "Invalid Email")]
        //public string Email { get; set; }

        [NotMapped]
        public string FullName { get { return FirstName + ' ' + LastName; } set { value = FirstName + ' ' + LastName; } }

        public UserStatus UserStatus { get; set; }

        //[NotMapped]
        //public virtual Connection Connection { get; set; }

    }
    public enum UserStatus
    {
        Waiting = 1, Pending = 2, Active = 3
    }

    //public class ApplicationRoles : IdentityRole
    //{

    //}

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("BorsaCapitalSecurity", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        public DbSet<Connection> Connections { get; set; }



        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    //modelBuilder.Entity<IdentityUserLogin>()
        //    // .HasKey(r => new { r.LoginProvider, r.ProviderKey,r.UserId })
        //    // .ToTable("UserLogins");

        //    //modelBuilder.Entity<IdentityUserRole>()
        //    //.HasKey(r => new { r.RoleId, r.UserId })
        //    //.ToTable("UserRoles");

        //    //modelBuilder.Entity<IdentityUser>()
        //    //.HasKey(r => new { r.Id })
        //    //.ToTable("Users");

        //    //modelBuilder.Entity<IdentityUserClaim>()
        //    //.HasKey(r => new { r.Id })
        //    //.ToTable("UserClaims");

        //    //modelBuilder.Entity<IdentityRole>()
        //    //.HasKey(r => new { r.Id })
        //    //.ToTable("Roles");

        //    //modelBuilder.Entity<Connection>()
        //    //.HasKey(r => new { r.ConnectionId })
        //    //.ToTable("Connections");

        //    //modelBuilder.Entity<ApplicationUser>().ToTable("Users");
        //    //modelBuilder.Entity<IdentityRole>().ToTable("Roles");
        //    //modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
        //    //modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
        //    //modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");

        //    modelBuilder.Entity<Connection>()
        //        .HasKey(t => t.UserId);

        //    modelBuilder.Entity<Connection>()
        //        .HasOptional(a => a.User)
        //        .WithOptionalDependent()
        //        .WillCascadeOnDelete(true);

        //    //modelBuilder.Entity<ApplicationUser>()
        //    //    .HasRequired(a => a.Connection)
        //    //    .WithRequiredDependent(a => a.User)
        //    //    .WillCascadeOnDelete(true);

        //    //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();



        //    //modelBuilder.Entity<ApplicationUser>()
        //    //    .HasRequired(t => t.Connection)
        //    //    .WithRequiredPrincipal(t => t.User)
        //    //    .WillCascadeOnDelete(true);

        //}

    }

    public class Staff
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public UserStatus UserStatus { get; set; }
        public List<string> Roles { get; set; }

    }
}