using CINEMA.API.DTO.Reservation;
using CINEMA.API.DTO.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CINEMA.API.DTO.User
{
    public class UserResponse
    {
        public int UserID { get; set; }
        public string username { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int roleID { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
        public UserRoleResponse role { get; set; }
        public ICollection<ReservationResponse> reservations { get; set; }
    }
}
