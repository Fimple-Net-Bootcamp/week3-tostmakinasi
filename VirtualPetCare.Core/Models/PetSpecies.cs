using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetCare.Core.Models
{
    public class PetSpecies : BaseModel
    {
        public string Species { get; set; }
        public List<Pet> Pets { get; set; }

        public List<Activity> Activities { get; set; }
    }
}
