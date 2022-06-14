using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Plastic : BaseEntity
    {
        public int id { get; set; }
        public string Name { get; set; }        
        public int PlasticTypeId { get; set; }
        public int size { get; set; }
        public int wt { get; set; }
        public PlasticType PlasticType { get; set; }
        public DateTime EstPossessionOn { get; set; }
        public string Description { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public DateTime PostedOn { get; set; } = DateTime.Now;
        
        [ForeignKey("User")]
        public int PostedBy { get; set; } 
        public User User { get; set; }       
    }
}