using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KOLOKWIUM2.Models;

[Table("Artist")]
public class Artist
{
    
    [Key]
    public int ArtistId { get; set; }
    
    [Required]
    [StringLength(100)]
    public string FirstName { get; set; }
    
    
    [Required]
    [StringLength(100)]
    public string LastName { get; set; }
    
    [Required]
    public DateTime BirthDate { get; set; }

    [Required] public ICollection<Artwork> Artworks { get; set; } = new List<Artwork>();
}