using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace FrontendMovieApp.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Movie Name is Required.")]
        [StringLength(50)]
        public required string Name { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Price must be between 1 and 100")]
        public decimal Price { get; set; }

        //Navigation property
        [ValidateNever]
        public Genre? Genre { get; set; }

        //Foreign key property
        [Required(ErrorMessage = "Genre is required")]
        public int GenreId { get; set; }

        public DateOnly ReleaseDate { get; set; }
    }
}
