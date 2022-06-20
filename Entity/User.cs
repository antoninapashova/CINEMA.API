using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CINEMA.API.Entity
{
    public class User
    {
        public int UserID { get; set; }
        public string username { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }
        public int roleID { get; set; }

        public string email { get; set; }

        public string phone { get; set; }

        public string password { get; set; }
        public UserRole role { get; set; }
        public DateTime lastModified_18118032 { get; set; }
        public ICollection<Reservation> reservations { get; set; }
    }
}
