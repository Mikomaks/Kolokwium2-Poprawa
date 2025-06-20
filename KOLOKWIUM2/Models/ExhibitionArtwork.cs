using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KOLOKWIUM2.Models;

[PrimaryKey(nameof(ExhibitionId), nameof(ArtworkId))]
[Table("ExhibitionArtwork")]
public class ExhibitionArtwork
{
    
    [ForeignKey("Exhibition")]
    public int ExhibitionId { get; set; }
    public Exhibition Exhibition { get; set; }
    
    [ForeignKey("Artwork")]
    public int ArtworkId { get; set; }
    public Artwork Artwork { get; set; }
    
    [Column(TypeName = "decimal(10,2)")]
    public decimal InsuranceValue { get; set; }
    
}