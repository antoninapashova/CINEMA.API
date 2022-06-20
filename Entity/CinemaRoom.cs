using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CINEMA.API.Entity
{
    public class CinemaRoom
    {
        public int CinemaRoomID { get; set; }
        public string number { get; set; }
        public int seats { get; set; }
        public ICollection<Film> films;
        public DateTime lastModified_18118032 { get; set; }
    }
}
