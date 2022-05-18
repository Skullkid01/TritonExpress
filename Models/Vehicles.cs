using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace TritonExpress.Models
{
    public partial class Vehicles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VehicleId { get; set; }
        [Required]
        [DisplayName("Manufacturer")]
        public string vehicleName { get; set; }

        [Required]
        [DisplayName("Vehicle Registration")]
        public string vehicleRegistration { get; set; }

        [Required]
        [DisplayName("Type")]
        public string vehicleType { get; set; }

        [DisplayName("Model")]
        public string vehicleModel { get; set; }

        [Required]
        [DisplayName("Allocate A Branch")]
        public int BranchId { get; set; }

        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }

        public virtual ICollection<WayBill> WayBills { get; set; }


    }
}
