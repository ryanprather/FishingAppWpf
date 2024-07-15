using FishingApp.Storage.Service.NoaaService.Models;

namespace FishingApp.Storage.Service.NoaaService
{
    public interface INoaaQueryService
    {
        IEnumerable<NOAALocation> GetNoaaActiveLocations();
    }
}
