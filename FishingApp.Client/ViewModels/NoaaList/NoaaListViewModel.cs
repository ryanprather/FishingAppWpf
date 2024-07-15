using FishingApp.Client.ViewModels.Abstract;
using FishingApp.Storage.Service.NoaaService;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;

namespace FishingApp.Client.ViewModels.NoaaList
{
    public class NoaaListViewModel : ViewModelBase, INoaaListViewModel
    {
        private readonly INoaaQueryService _noaaQueryService;
        public Visibility ShowLoading { get; set; }
        public ObservableCollection<BouyListItem> BouyLocations { get; }
        private object _myCollectionLock = new object();

        public NoaaListViewModel(INoaaQueryService noaaQueryService)
        {
            _noaaQueryService = noaaQueryService;
            BouyLocations = new ObservableCollection<BouyListItem>();
            ShowLoading = Visibility.Visible;
            BindingOperations.EnableCollectionSynchronization(BouyLocations, _myCollectionLock);
        }

        public void LoadNoaaLocations()
        {
            BouyLocations.AddRange(_noaaQueryService.GetNoaaActiveLocations().Select(s=> new BouyListItem(s.Name, s.LocationId, s.Latitude, s.Longitude, s.Type)));
            ShowLoading = Visibility.Hidden;
            base.OnPropertyChanged(nameof(ShowLoading));
        }
}
}
