using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetCare.Core.DTOs.Pet
{
    public class PetCreateDto
    {
        public int OwnerId { get; set; }
        public int PetSpeciesId { get; set; }
        public string PetName { get; set; }
    }
}
