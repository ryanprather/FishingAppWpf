using FishingApp.Client.ViewModels.Abstract;
using MaterialDesignThemes.Wpf;

namespace FishingApp.Client.ViewModels.NoaaList
{
    public class BouyListItem: ViewModelBase
    {
        public string Name { get; }
        public String LocationId { get;}
        public double Latitude { get;}
        public double Longitude { get;}
        public String Type { get; set; }
        public PackIconKind PackIcon { get { return PackIconKind.Globe; }}
        public BouyListItem(string name, string locationId, double latitude, double longitude, String type) 
        {
            Name = name;
            LocationId = locationId;
            Latitude = latitude;
            Longitude = longitude;
            Type = type;
        }
    }
}
