using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetCare.Core.Models
{
    public class Activity : BaseModel
    {
        public string Name { get; set; }
        public int HealthEffect { get; set; }

        public List<ActivityHistory> ActivityHistories { get; set; }
        public List<PetSpecies> PetSpecies { get; set; }
    }
}
