using CINEMA.API.DTO.Film;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CINEMA.API.DTO.CinemaRoom
{
    public class CinemaRoomResponse
    {
       
        public int cinemaRoomId { get; set; }
        public string number { get; set; }
        public int seats { get; set; }
        public ICollection<FilmResponse> films;
    }
}
