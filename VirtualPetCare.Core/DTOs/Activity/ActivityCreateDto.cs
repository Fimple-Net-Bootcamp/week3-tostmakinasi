using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs.PetSpecies;
using VirtualPetCare.Core.Models;

namespace VirtualPetCare.Core.DTOs.Activity
{
    public class ActivityCreateDto
    {
        public string Name { get; set; }
        public int HealthEffect { get; set; }

        public List<PetSpeciesForActivityCreateDto> PetSpeciesIds { get; set; }
    }
}
