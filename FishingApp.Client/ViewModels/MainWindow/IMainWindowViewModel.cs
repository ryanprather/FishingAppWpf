using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FishingApp.Client.ViewModels.MainWindow
{
    public interface IMainWindowViewModel
    {
        IEnumerable<NavMenuItem?> GetUserControls(string searchNamespace);
    }
}
