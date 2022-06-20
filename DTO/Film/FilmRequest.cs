using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CINEMA.API.DTO.Film
{
    public class FilmRequest
    {
        public string name { get; set; }
        public string description { get; set; }
        public int genreID { get; set; }
        public int cinemaRoomID { get; set; }
        public double ticketPrice { get; set; }
        public string duration { get; set; }
        public DateTime start { get; set; }
      
        public DateTime lastModified_18118032 { get; set; }
    }
}
