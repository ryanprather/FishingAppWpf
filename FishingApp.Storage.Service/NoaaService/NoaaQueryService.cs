using FishingApp.Storage.Context;
using FishingApp.Storage.Service.NoaaService.Models;
using System.Data;
using System.Xml.Linq;

namespace FishingApp.Storage.Service.NoaaService
{
    public class NoaaQueryService: INoaaQueryService
    {
        private readonly string _connectionString;
        private readonly string _webServiceQueryString;

        public NoaaQueryService(string noaaConnection, string webServiceQueryString)
        {
            _connectionString = noaaConnection;
            _webServiceQueryString = webServiceQueryString;
        }

        public async Task<IEnumerable<NOAALocation>> GetNoaaActiveLocations()
        {
            var stations = new List<NOAALocation>();
            var client = new HttpClient();
            var response = await client.GetStreamAsync(_connectionString);
            XDocument xmlDoc = XDocument.Load(response);
            foreach (var xmlStation in xmlDoc.Descendants("station"))
            {
                if (xmlStation != null && xmlStation.Attribute("met") != null && xmlStation.Attribute("met").Value == "y")
                {
                    var station = new NOAALocation()
                    {
                        LocationId = (xmlStation.Attribute("id") != null && xmlStation.Attribute("id").Value != null) ? xmlStation.Attribute("id").Value : "",
                        Latitude = (xmlStation.Attribute("lat") != null && xmlStation.Attribute("lat").Value != null) ? double.Parse(xmlStation.Attribute("lat").Value) : 0,
                        Longitude = (xmlStation.Attribute("lon") != null && xmlStation.Attribute("lon").Value != null) ? double.Parse(xmlStation.Attribute("lon").Value) : 0,
                        Name = (xmlStation.Attribute("name") != null && xmlStation.Attribute("name").Value != null && xmlStation.Attribute("name").Value != String.Empty) ? xmlStation.Attribute("name").Value : "N/A",
                        Type = (xmlStation.Attribute("type") != null && xmlStation.Attribute("type").Value != null && xmlStation.Attribute("type").Value != String.Empty) ? xmlStation.Attribute("type").Value : "N/A",
                    };
                    stations.Add(station);
                }
            }

            return stations;
        }

        public async void GetNoaa_Waves(Models.NOAALocation noaaLocation)
        {
            var formatted_NOAAWebService = _webServiceQueryString.Replace("@@ObservedProperty", "waves").Replace("@StationID", noaaLocation.LocationId);
            var client = new HttpClient();
            var response = await client.GetStreamAsync(formatted_NOAAWebService);
        }

    }
}
