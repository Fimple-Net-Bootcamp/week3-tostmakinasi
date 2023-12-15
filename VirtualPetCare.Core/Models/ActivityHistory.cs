using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetCare.Core.Models
{
    public class ActivityHistory : BaseModel
    {
        public int PetId { get; set; }
        public int ActivityId { get; set; }
        public int HealthEffect { get; set; }

        public Activity Activity { get; set; }
        public Pet Pet { get; set; }
    }
}
