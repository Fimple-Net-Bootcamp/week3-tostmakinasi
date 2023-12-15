using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetCare.Core.Models
{
    public class Health : BaseModel
    {
        public int Status { get; set; }
        public bool IsAlive { get; set; }

        public Pet Pet { get; set; }
    }
}
