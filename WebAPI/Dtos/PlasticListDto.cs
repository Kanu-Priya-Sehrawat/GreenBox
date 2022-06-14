using System;

namespace WebAPI.Dtos
{
    public class PlasticListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PlasticType { get; set; }
        public int wt { get; set; }
        public int size { get; set; }
        public DateTime EstPossessionOn { get; set; }
        public string Photo { get; set; }
    }
}