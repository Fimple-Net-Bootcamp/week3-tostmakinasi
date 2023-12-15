using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs.Pet;

namespace VirtualPetCare.Core.DTOs.User
{
    public class UserDto:BaseModelDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<PetUserDetailDto> Pets{ get; set; }
    }
}
