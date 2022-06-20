using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CINEMA.API.Entity
{
    public class Film
    {
        public int FilmID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int genreID { get; set; }
        public int cinemaRoomId { get; set; }
        public double ticketPrice { get; set; }
        public string duration { get; set; }
        public DateTime start { get; set; }
     
        public Genre genre { get; set; }
        public CinemaRoom cinemaRoom { get; set; }
        public DateTime lastModified_18118032 { get; set; }
        public ICollection<Reservation> reservations { get; set; }
    }
}
