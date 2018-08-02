using System.ComponentModel.DataAnnotations;

namespace amidus.Core.Models
{
    public class Actor
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(255)]
        public string LastName { get; set; }
        [Required]
        [StringLength(2048)]
        public string Description { get; set; }
    }
}