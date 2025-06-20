using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KOLOKWIUM2.DTOs;

public class AddNewExhibitonDTO
{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; }
    
    
    [Required]
    [MaxLength(50)]
    public string GalleryName { get; set; }
    
    
    [Required]
    public DateTime StartDate { get; set; }
    
    [Required]
    public DateTime? EndDate { get; set; }
    
    [Required]
    public List<ArtworkAddDTO> Artworks { get; set; } = new List<ArtworkAddDTO>();
}

public class ArtworkAddDTO
{
    [Required]
    public int ArtworkId { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal InsuranceValue { get; set; }
}