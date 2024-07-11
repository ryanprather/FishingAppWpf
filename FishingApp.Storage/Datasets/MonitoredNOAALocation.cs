using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingApp.Storage.Datasets
{
    public class MonitoredNOAALocation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MonitoredNOAALocationID { get; set; }

        [Required]
        public bool IsDefault { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string StationId { get; set; }

        public string Type { get; set; }

        public DateTime? CreatedDate { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
