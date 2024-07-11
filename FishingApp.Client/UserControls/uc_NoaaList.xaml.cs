using MaterialDesignThemes.Wpf;
using System.Windows.Controls;

namespace FishingApp.Client.UserControls
{
    /// <summary>
    /// Interaction logic for uc_NoaaList.xaml
    /// </summary>
    public partial class uc_NoaaList : UserControl, IBaseUserControl
    {
        public uc_NoaaList()
        {
            InitializeComponent();
        }

        public PackIconKind GetSelectedPackingIcon()
        {
            return PackIconKind.AccessPoint;
        }

        public PackIconKind GetUnselectedPackingIcon()
        {
            return PackIconKind.AccessPoint;
        }
    }
}
