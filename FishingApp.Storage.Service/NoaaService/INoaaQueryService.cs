using FishingApp.Storage.Service.NoaaService.Models;

namespace FishingApp.Storage.Service.NoaaService
{
    public interface INoaaQueryService
    {
        Task<IEnumerable<NOAALocation>> GetNoaaActiveLocations();
    }
}
