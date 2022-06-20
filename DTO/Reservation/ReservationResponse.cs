using CINEMA.API.DTO.Film;
using CINEMA.API.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CINEMA.API.DTO.Reservation
{
    public class ReservationResponse
    {
        public int ReservationID { get; set; }
  
        public UserResponse user { get; set; }
        public FilmResponse film { get; set; } 
        
        public int numberOfTickets { get; set; }
    }
}
