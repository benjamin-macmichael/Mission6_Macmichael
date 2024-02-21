using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//This is the Model that will be used when building the database structure
//All fields cannot be null except for Edited, LentTo, and Notes
namespace Mission6_Macmichael.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        //public Categories? Categories { get; set; } -- This line is commented out because it was causing errors, and the app works perfectly fine without it
        [Required]
        public string Title { get; set; }
        [Required, Range(1888,2024)]
        public string Year { get; set; }
        public string? Director { get; set; }
        public string? Rating { get; set; }
        [Required]
        public bool Edited { get; set; }
        public string? LentTo { get; set; }
        [Required]
        public bool CopiedToPlex { get; set; }
        [MaxLength(25)]
        public string? Notes { get; set; }
    }
}
