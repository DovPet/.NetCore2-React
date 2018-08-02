using System.ComponentModel.DataAnnotations;

namespace amidus.Core.Models
{
    public class Genre
    {
        public int Id { get; set; }        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [StringLength(2048)]
        public string Description { get; set; }
    }
}