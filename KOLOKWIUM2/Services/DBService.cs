using KOLOKWIUM2.Data;
using KOLOKWIUM2.DTOs;
using KOLOKWIUM2.Models;
using Microsoft.EntityFrameworkCore;

namespace KOLOKWIUM2.Services;

public class DBService : IDBService
{

    private readonly DBContext _context;

    public DBService(DBContext context)
    {
        _context = context;
    }



    public async Task<GetExhibitionsDTO> GetExhibitionsFromGalleryID(int id)
    {
        /*
         * Include(g => g.Exhibitions)
           .ThenInclude(ex => ex.Artworks)
           .FirstOrDefaultAsync(g => g.GalleryId == id);
         */
        var gallery = await _context.Galleries
            .Include(g => g.Exhibitions)
            .ThenInclude(ex => ex.Artworks)
            .ThenInclude(a => a.Artwork).ThenInclude(artwork => artwork.Artist)
            .FirstOrDefaultAsync(g => g.GalleryId == id);

        if (gallery == null)
        {
            return null;
        }


        return new GetExhibitionsDTO()
        {
            GalleryId = gallery.GalleryId,
            Name = gallery.Name,
            EstablishedDate = gallery.EstablishedDate,
            Exhibitions = gallery.Exhibitions.Select(ex => new ExhibitionDTO()
            {
                Title = ex.Title,
                StartDate = ex.StartDate,
                EndDate = ex.EndDate,
                NumberOfArtworks = ex.NumberOfArtworks,
                Artworks = ex.Artworks.Select(a => new ArtworkDTO()
                {
                    Title = a.Artwork.Title,
                    YearCreated = a.Artwork.YearCreated,
                    InsuranceValue = a.InsuranceValue,
                    Artist = new ArtistDTO()
                    {
                        FirstName = a.Artwork.Artist.FirstName,
                        LastName = a.Artwork.Artist.LastName,
                        Birthdate = a.Artwork.Artist.BirthDate
                    }
                }).ToList()
            }).ToList()
        };

    }


    public async Task<int> AddExhibition(AddNewExhibitonDTO request)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var gallery = await _context.Galleries
                .Include(g => g.Exhibitions)
                .FirstOrDefaultAsync(g => g.Name == request.GalleryName);

            var galleryExists = gallery != null;

            if (!galleryExists)
            {
                return -1; //galeria nie istnieje
            }


            var newExhibition = new Exhibition
            {
                Title = request.Title,
                GalleryId = gallery.GalleryId,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                NumberOfArtworks = request.Artworks.Count
            };
            _context.Exhibitions.Add(newExhibition);
            await _context.SaveChangesAsync();

            //dodana wystawa teraz kazdego artworka

            //SPRAWDZANIE CZY ARTWORKI ISTNIEJA
            foreach (var artwork in request.Artworks)
            {
                var artworkfromDB = await _context.Artworks
                    .Include(a => a.Artist)
                    .FirstOrDefaultAsync(a => a.ArtworkId == artwork.ArtworkId);

                if (artworkfromDB == null)
                {
                    return -2; //artwork nie istnieje
                }
            }

            //dodawanie exhibitonartwork
            foreach (var artwork in request.Artworks)
            {
                var newExhArtw = new ExhibitionArtwork()
                {
                    ExhibitionId = newExhibition.ExhibitionId,
                    ArtworkId = artwork.ArtworkId,
                    InsuranceValue = artwork.InsuranceValue
                };
                
                _context.ExhibitionArtworks.Add(newExhArtw);
                await _context.SaveChangesAsync();
            }
            
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
        await transaction.CommitAsync();
        return 0;
    }
}

