#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ChefsNDishes.Models;
public class Dish
{
  [Key]
  public int DishId { get; set; }
  [Required]
  [MinLength(2, ErrorMessage = "must be at least 2 characters.")]
  [MaxLength(30, ErrorMessage = "must be at most 30 characters.")]
  public string Name { get; set; }
  [Required(ErrorMessage = "The Tastiness field is required.")]
  [Range(1, 5, ErrorMessage = "Tastiness must be between 1 and 5.")]
  public int Tastiness { get; set; }
  [Required(ErrorMessage = "The Calories field is required.")]
  [Range(1, int.MaxValue, ErrorMessage = "Calories must be greater than 0.")]
  public int Calories { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.Now;
  public DateTime UpdatedAt { get; set; } = DateTime.Now;
  public int ChefId { get; set; }
  public Chef? Creator { get; set; }
}