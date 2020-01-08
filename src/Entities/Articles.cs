using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

namespace netCoreWorkshop.Entities
{
    public class Article : IEntityBase
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }      
                
        public string Price { get; set; }
    }
}