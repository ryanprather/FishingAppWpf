using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingApp.Storage.Service.NoaaService.Models
{
    public class NOAALocation
    {
        public String LocationId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public String Name { get; set; }
        public String Type { get; set; }
    }
}
