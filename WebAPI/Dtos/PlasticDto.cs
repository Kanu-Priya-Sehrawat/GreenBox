using System;

namespace WebAPI.Dtos
{
    public class PlasticDto
    {
        
        public int Id { get; set; }
        public string Name { get; set; }        
        public int PlasticTypeId { get; set; }
        public int size { get; set; }
        public int wt { get; set; }
        public PlasticType PlasticType { get; set; }
        public DateTime EstPossessionOn { get; set; }
        public string Description { get; set; }
           

      
    }
}