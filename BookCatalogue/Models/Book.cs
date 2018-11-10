using System.ComponentModel.DataAnnotations;

namespace BookCatalogue.Models
{
    public enum Genre
    {
        Novel, Detective, Fantasy, Adventure
    }
    public class Book
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }

        [Display(Name = "Year of publication")]
        [Required(ErrorMessage = "Year is required")]
        public int Year { get; set; }

        [Display(Name = "Publishing House")]
        [Required(ErrorMessage = "Publishing House is required")]
        public string PublishingHouse { get; set; }

        public Genre Genre { get; set; }
    }
}