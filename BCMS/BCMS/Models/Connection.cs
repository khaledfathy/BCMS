using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BCMS.Models
{
    public class Connection
    {
        public string ConnectionId { get; set; }

        public string UserId { get; set; }

        public string Email { get; set; }
        
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }


    }
}