using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BCMS.Models
{
    public static class AdminHelpers
    {
        public static Boolean IsAdminUser(string UserId)
        {
            try
            {
                ApplicationDbContext context = new ApplicationDbContext();
                var user = context.Users.Where(a => a.Id == UserId).Select(a => a.Roles).FirstOrDefault();
                if (user.Count == 0)
                {
                    return false;
                }
                else
                {
                    foreach (var item in user)
                    {
                        var RoleName = context.Roles.Where(a => a.Id == item.RoleId).Select(a => a.Name).FirstOrDefault();
                        if (RoleName == "Admin")
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}