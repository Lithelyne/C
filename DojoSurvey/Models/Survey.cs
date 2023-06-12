using System.ComponentModel.DataAnnotations;
namespace DojoSurvey.Models;


public class Survey 
{
    [Required(ErrorMessage = "is required")]
    [MinLength(2, ErrorMessage = "your name must be minimum 2 characters")]
    public string Name { get; set;}

    public string Location { get; set;}

    public string Language { get; set; }

    [MinLength(20, ErrorMessage = "Comments must be 20 characters or empty.")]

    public string? Comments { get; set;}
}