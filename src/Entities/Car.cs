using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

namespace netCoreWorkshop.Entities
{
    public class Car : IEntityBase
    {
        public int Id { get; set; }

        [Required]
        public string Model { get; set; }

        public string Brand { get; set; }

        public double Price { get; set; }
    }
}