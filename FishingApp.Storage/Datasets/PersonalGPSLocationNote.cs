using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingApp.Storage.Datasets
{
    public class PersonalGPSLocationNote
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PersonalGPSLocationNoteID { get; set; }

        [ForeignKey("PersonalGPSLocationID")]
        public Guid PersonalGPSLocationID { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime FishingDate { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
