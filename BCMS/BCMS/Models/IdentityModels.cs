using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

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