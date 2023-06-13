using System.ComponentModel.DataAnnotations;
namespace SessionWorkshop.Models;
public class Survey
{
    [Required(ErrorMessage = "is required")]
    [MinLength(2, ErrorMessage="Message must be at least 2 characters in length.")]
    public string Name { get; set; }
}