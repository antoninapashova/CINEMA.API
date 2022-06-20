using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CINEMA.API.Entity
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int userID { get; set; }
        public int filmId { get; set; }
        public User user { get; set; }
        public Film film { get; set; }
        public int numberOfTickets { get; set; }
        public DateTime lastModified_18118032 { get; set; }
    }
}
