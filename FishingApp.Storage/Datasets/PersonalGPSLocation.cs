using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingApp.Storage.Datasets
{
    public class PersonalGPSLocation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PersonalGPSLocationID { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        public required string Name { get; set; }

        public int WaterDepth { get; set; }

        public string? Description { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

    }
}
