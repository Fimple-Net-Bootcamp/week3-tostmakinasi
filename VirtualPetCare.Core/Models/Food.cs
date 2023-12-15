using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetCare.Core.Models
{
    public class Food : BaseModel
    {
        public string Name { get; set; }
        public int HealthEffect { get; set; }
        public List<FoodHistory> FoodHistories { get; set; }
    }
}
