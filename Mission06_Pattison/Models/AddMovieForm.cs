using System.ComponentModel.DataAnnotations;

namespace Mission06_Pattison.Models
{
    public class AddMovieForm
    {
        [Key]
        [Required]
        public int MovieID { get; set; }

        [Required]
        public string? Category { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string? Director { get; set; }

        [Required]
        public string? Rating { get; set; }

        public bool Edited { get; set; }

        public string? LentTo { get; set; }

        [MaxLength(25, ErrorMessage = "Notes must be 25 characters or less.")]
        public string? Notes { get; set; }
    }
}
