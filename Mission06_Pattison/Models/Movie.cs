using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Pattison.Models
{
    [Table("Movies")]
    public class Movie
    {
        [Key]
        public int MovieId { get; set; } // Primary Key

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; } // Nullable Foreign Key

        public Category? Category { get; set; } // Navigation Property

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")]
        public int Year { get; set; }



        public string? Director { get; set; } // Nullable

        public string? Rating { get; set; } // Nullable

        [Required]
        public bool Edited { get; set; }

        public string? LentTo { get; set; } // Nullable

        [Required]
        public bool CopiedToPlex { get; set; }

        public string? Notes { get; set; } // Nullable
    }
}
