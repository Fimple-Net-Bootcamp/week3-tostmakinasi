using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetCare.Core.DTOs.Pet
{
    public class PetListDto : BaseModelDto
    {
        public string PetName { get; set; }
        public string Species { get; set; }
        public string Age { get; set; }
        public string HealtStatus { get; set; }
    }
}
