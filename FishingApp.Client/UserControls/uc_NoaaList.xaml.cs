using FishingApp.Client.ViewModels.NoaaList;
using MaterialDesignThemes.Wpf;
using System.Windows.Controls;

namespace FishingApp.Client.UserControls
{
    /// <summary>
    /// Interaction logic for uc_NoaaList.xaml
    /// </summary>
    public partial class uc_NoaaList : UserControl, IBaseUserControl
    {
        private readonly INoaaListViewModel _noaaListViewModel;
        public uc_NoaaList(INoaaListViewModel noaaListViewModel)
        {
            InitializeComponent();
            _noaaListViewModel = noaaListViewModel;
            DataContext = _noaaListViewModel;
        }

        public PackIconKind GetSelectedPackingIcon()
        {
            return PackIconKind.AccessPoint;
        }

        public PackIconKind GetUnselectedPackingIcon()
        {
            return PackIconKind.AccessPoint;
        }

        private void View_Noaa_Bouy_List_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            _noaaListViewModel.LoadNoaaLocations();
        }

        


    }
}
