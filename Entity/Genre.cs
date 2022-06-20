using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CINEMA.API.Entity
{
    public class Genre
    {
        public int GenreID { get; set; }
        public string Name { get; set; }
        public DateTime lastModified_18118032 { get; set; }
        public ICollection<Film> films { get; set; }
    }
}
