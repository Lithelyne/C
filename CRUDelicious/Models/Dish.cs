using System.ComponentModel.DataAnnotations;
namespace CRUDelicious;


public class Dish
{
    [Key]
    public int PostID { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "must be at least 2 characters")]
    [MaxLength(30, ErrorMessage = "cannot excede 20 characters")]

    public string Name { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "must be at least 2 characters")]
    [MaxLength(30, ErrorMessage = "cannot excede 30 characters")]

    public string Chef { get; set; }

    [Required]
    [Range(1, 5, ErrorMessage = "Must be greater than 1")]
    public int Tastiness { get; set; }

    [Required]
    [Range(1, 100000, ErrorMessage = "Must be greater than 1")]
    public int Calories { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "must be at least 2 characters")]
    public string Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAT { get; set; } = DateTime.Now;
}