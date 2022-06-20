using CINEMA.API.DTO.CinemaRoom;
using CINEMA.API.DTO.Genre;
using System;


namespace CINEMA.API.DTO.Film
{
    public class FilmResponse
    {
        public int FilmID { get; set; }
        public string name { get; set; }

        public string description { get; set; }
   
        public double ticketPrice { get; set; }
        public string duration { get; set; }
        public DateTime start { get; set; }
        public GenreResponse genre { get; set; }
        public CinemaRoomResponse cinemaRoom { get; set; }

    
    }
}
