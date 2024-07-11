using FishingApp.Client.UserControls;
using FishingApp.Client.ViewModels.Abstract;
using MaterialDesignThemes.Wpf;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Documents;

namespace FishingApp.Client.ViewModels.MainWindow
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        private NavMenuItem? _selectedItem;
        private int _selectedIndex;

        public NavMenuItem? SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        public int SelectedIndex
        {
            get => _selectedIndex;
            set => SetProperty(ref _selectedIndex, value);
        }

        public ObservableCollection<NavMenuItem> NavMenuItems { get; }

        public MainWindowViewModel() 
        {
            NavMenuItems = new ObservableCollection<NavMenuItem>();
            var navitems = GetUserControls("FishingApp.Client");
            if (navitems == null) return;
            foreach (var item in navitems) 
            {
                NavMenuItems.Add(item);
            }
        }


        public IEnumerable<NavMenuItem> GetUserControls(string searchNamespace) 
        {
            return Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.FullName.StartsWith(searchNamespace)
                    && typeof(UserControl).IsAssignableFrom(t))
                .Select(t => (UserControl)Activator.CreateInstance(t))
                .Select(x=> new NavMenuItem(
                    name: x.Name.Replace("_", " "),
                    contentType: x.GetType(),
                    selectedIcon: PackIconKind.Home,
                    unselectedIcon: PackIconKind.Home
                    ));
        }


    }
}
