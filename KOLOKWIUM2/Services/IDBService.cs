using KOLOKWIUM2.DTOs;

namespace KOLOKWIUM2.Services;

public interface IDBService
{
    public Task<GetExhibitionsDTO> GetExhibitionsFromGalleryID(int id);

    public Task<int> AddExhibition(AddNewExhibitonDTO request);
}