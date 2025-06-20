using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KOLOKWIUM2.Models;

[Table("Gallery")]
public class Gallery
{
 
    [Key]
    public int GalleryId { get; set; }
    
    [Required]
    [StringLength(50)]
    public string Name { get; set; }
    
    [Required]
    public DateTime EstablishedDate { get; set; }
    
    [Required]
    public ICollection<Exhibition> Exhibitions { get; set; } = new List<Exhibition>();
    
}