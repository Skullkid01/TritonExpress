using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace TritonExpress.Models
{
    public partial class Branch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BranchId { get; set; }
        [Required]
        [DisplayName("Triton Branch Name")]
        public string branchName { get; set; }

        [Required]
        [DisplayName("Location")]
        public string location { get; set; }

        public virtual ICollection<Vehicles> Vehicles { get; set; }
    }
}
