using KOLOKWIUM2.DTOs;
using KOLOKWIUM2.Services;
using Microsoft.AspNetCore.Mvc;

namespace KOLOKWIUM2.Controllers;

[Route("api/")]
[ApiController]
public class MyController : ControllerBase
{
    
    private readonly IDBService _dbService;

    public MyController(IDBService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("galleries/{id}/exhibitions")]
    public async Task<IActionResult?> GetCustomerPurchases(int id)
    {
        var gallery = await _dbService.GetExhibitionsFromGalleryID(id);
        
        if (gallery is null)
            return NotFound($"Taka galeria nie istnieje!");
        else
        {
            return Ok(gallery);
        }
    }
    

    [HttpPost("exhibitions")]
    public async Task<IActionResult> AddNewExhibitions(AddNewExhibitonDTO request)
    {
        var result = await _dbService.AddExhibition(request);

        if (result == -1)
        {
            return NotFound("Nie znaleziono takiej galerii");
        }
        else if (result == -2)
        {
            return NotFound("Jedno z dziel sztuki nie istnieje!");
        }
        
        
        return Ok("Pomyślnie dodano wystawę!");
    }
    
     
    
}