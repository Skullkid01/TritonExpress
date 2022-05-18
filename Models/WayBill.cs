using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace TritonExpress.Models
{
    public partial class WayBill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int wayBillId { get; set; }
        [DisplayName("Way Bill Reference")]     
        public string wayBillReference { get; set; }
        [Required]
        [DisplayName("Total Weight")]
        public double totalWeight { get; set; }
        [Required]
        [DisplayName("Total Parcel(s)")]
        public int parcels { get; set; }

        [Required]
        [DisplayName("Assign To Vehicle")]
        public int VehicleId { get; set; }

        [ForeignKey("VehicleId")]
        public  Vehicles Vehicles { get; set; }

        public string GetWayRef()
        {
            Guid g = Guid.NewGuid();
            var date = DateTime.UtcNow.ToString("yyyy-MM-hh:mm");

            var wayBillRef = "TExpress-"+ g + date;

            return wayBillRef;

        }
    }
}
