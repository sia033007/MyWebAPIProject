using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPIProject.Model
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MovieGenre> MovieGenres { get; set; }
        public string Director { get; set; }
        public DateTime ReleaseDate { get; set; } = DateTime.Now;

    }
}
