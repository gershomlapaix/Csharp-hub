using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models;

public class Movie
{
    public int Id { get; set; }
    public string? Title { get; set; }
    [Display(Name = "Release date")] // what display
    [DataType(DataType.Date)] // for specifying the datatype "Date"
    public DateTime ReleaseDate { get; set; }
    public string? Genre { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    // public string? Rating { get; set; }
}