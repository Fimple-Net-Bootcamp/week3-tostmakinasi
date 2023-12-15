using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs.Activity;

namespace VirtualPetCare.Core.DTOs.PetSpecies
{
    public class PetSpeciesDto : BaseModelDto
    {
        public string Species { get; set; }
    }
}
