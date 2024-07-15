using FishingApp.Storage.Service.NoaaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingApp.Client.ViewModels.NoaaList
{
    public interface INoaaListViewModel
    {
        void LoadNoaaLocations();
    }
}
