using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CINEMA.API.DTO.Reservation
{
    public class ReservationRequest
    {
        public int userID { get; set; }
        public int filmId { get; set; }
        public int cinemaRoomId { get; set; }
        public int numberOfTickets { get; set; }
        public DateTime lastModified_18118032 { get; set; }
    }
}
