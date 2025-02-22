using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mission06_Pattison.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; } // Primary Key

        [Required]
        public string CategoryName { get; set; } = string.Empty;

        // Ensure this navigation property exists
        public List<Movie>? Movies { get; set; }
    }
}
