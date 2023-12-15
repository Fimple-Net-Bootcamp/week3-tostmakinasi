using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetCare.Core.DTOs.Activity
{
    public class ActivityForSpeciesDto : BaseModelDto
    {
        public string Name { get; set; }
        public int HealthEffect { get; set; }
    }
}
