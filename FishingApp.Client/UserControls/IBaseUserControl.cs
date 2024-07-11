using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingApp.Client.UserControls
{
    public interface IBaseUserControl
    {
        PackIconKind GetSelectedPackingIcon();
        PackIconKind GetUnselectedPackingIcon();
    }
}
