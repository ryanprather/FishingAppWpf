using FishingApp.Client.UserControls;
using FishingApp.Client.ViewModels.Abstract;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly string _localNamespace;

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

        public MainWindowViewModel(string localNamespace)
        {
            _localNamespace = localNamespace;
            NavMenuItems = new ObservableCollection<NavMenuItem>();
            
            var navitems = GetUserControls(_localNamespace);
            if (navitems == null) return;
            foreach (var item in navitems)
            {
                NavMenuItems.Add(item);
            }
        }


        public IEnumerable<NavMenuItem> GetUserControls(string searchNamespace)
        {
            var navList = new List<NavMenuItem>();

            var definedUserControls = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.FullName.StartsWith(searchNamespace)
                    && typeof(UserControl).IsAssignableFrom(t))
                .Select(t => (UserControl)App.ServiceProvider.GetRequiredService(t));


            foreach (var control in definedUserControls)
            {
                if (control is null) break;

                var baseControl = (IBaseUserControl)control;

                navList.Add(new NavMenuItem(
                    name: control.Name.Replace("_", " "),
                    contentType: control.GetType(),
                    selectedIcon: baseControl.GetSelectedPackingIcon(),
                    unselectedIcon: baseControl.GetUnselectedPackingIcon()
                    ));
            }

            return navList;
        }


    }
}
