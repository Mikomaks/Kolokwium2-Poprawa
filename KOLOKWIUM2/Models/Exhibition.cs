using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KOLOKWIUM2.Models;

[Table("Exhibition")]
public class Exhibition
{
    
    [Key]
    public int ExhibitionId { get; set; }
    
    [ForeignKey("Gallery")]
    public int GalleryId { get; set; }
    public Gallery Gallery { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string Title { get; set; }
    
    [Required]
    public DateTime StartDate { get; set; }
    
    public DateTime? EndDate { get; set; }
    
    [Required]
    public int NumberOfArtworks { get; set; }
    
    
    [Required]
    public ICollection<ExhibitionArtwork> Artworks { get; set; } = new List<ExhibitionArtwork>();
}