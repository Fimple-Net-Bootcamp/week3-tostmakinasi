using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs.PetSpecies;

namespace VirtualPetCare.Core.DTOs.Activity
{
    public class ActivityDto
    {
        public string Name { get; set; }
        public int HealthEffect { get; set; }

        List<PetSpeciesDto> PetSpecies { get; set; }
    }
}
