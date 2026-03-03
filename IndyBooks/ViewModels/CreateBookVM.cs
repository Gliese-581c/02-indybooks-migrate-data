
using System.ComponentModel.DataAnnotations;

namespace IndyBooks.ViewModels;
public class CreateBookVM
{
    //TODO: Add Properties for all of the data shown in the CreateBook View (see Fig.3)
    // Be sure to add Data Annotations for Validation and Error Messages as shown
    public long BookId { get; set; }


    [Required (ErrorMessage = "Title is required")]
    public string Title { get; set; }

    public string? Author { get; set; }

    public string? SKU { get; set; }

    public decimal Price { get; set; }

    public string? Year { get; set; }
}