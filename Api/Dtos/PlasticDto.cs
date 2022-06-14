 using System;
using WebAPI.Models;

namespace WebAPI.Dtos
{
    public class PlasticDto
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public int PlasticTypeId { get; set; }
        public PlasticType PlasticType { get; set; }
        public int size { get; set; }
        public int wt { get; set; }
        public int quantity { get; set; }
        public DateTime EstPossessionOn { get; set; } = DateTime.Now;
       
        public string Description { get; set; }
        public DateTime PostedOn { get; set; } = DateTime.Now;



    }
}