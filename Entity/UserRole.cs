using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CINEMA.API.Entity
{
    public class UserRole
    {
        public int UserRoleID { get; set; }
        public string role { get; set; }
        public DateTime lastModified_18118032 { get; set; }
        public ICollection<User> users { get; set; }
    }
}
