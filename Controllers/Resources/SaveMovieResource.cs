using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using amidus.Core.Models;

namespace amidus.Controllers.Resources
{
    public class SaveMovieResource
    {
        public int Id { get; set; }     
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public ICollection<int> Actors { get; set; }
        public SaveMovieResource()
        {
            Actors = new Collection<int>();
                      
        }
    }
}