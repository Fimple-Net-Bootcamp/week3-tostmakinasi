using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs.User;

namespace VirtualPetCare.Core.DTOs.Pet
{
    public class PetDto:BaseModelDto
    {
        public string PetName { get; set; }
        public string Age { get; set; }
        public string HealtStatus { get; set; }
        public UserPetDetailDto Owner  { get; set;}
    }
}
