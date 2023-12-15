using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetCare.Core.Models
{
    public class Pet:BaseModel
    {
        public int OwnerId { get; set; }
        public int PetSpeciesId { get; set; }

        [ForeignKey(nameof(Health))]
        public int HealthId { get; set; }
        public string PetName { get; set; }

        public User Owner { get; set; }
        public PetSpecies PetSpecies { get; set; }
        public Health Health { get; set; }

        public List<ActivityHistory>? ActivityHistories { get; set; }
        public List<FoodHistory>? FoodHistories { get; set; }
    }
}
