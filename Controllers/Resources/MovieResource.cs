using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using amidus.Core.Models;

namespace amidus.Controllers.Resources
{
    public class MovieResource
    {
        public int Id { get; set; }     
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public ICollection<ActorResource> Actors { get; set; }
        public MovieResource()
        {
            Actors = new Collection<ActorResource>();
                      
        }
    }
}