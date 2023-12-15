using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetCare.Core.DTOs.Health
{
    public class HealthDto:BaseModelDto
    {
        public int Status { get; set; }
        public bool IsAlive { get; set; }
    }
}
