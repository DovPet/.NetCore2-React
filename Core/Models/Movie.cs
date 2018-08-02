using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace amidus.Core.Models
{
    public class Movie
    {
        public int Id { get; set; }        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [StringLength(2048)]
        public string Description { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public ICollection<MovieActors> Actors { get; set; }
        public Movie()
        {
            Actors = new Collection<MovieActors>();
           
        }
    }
}