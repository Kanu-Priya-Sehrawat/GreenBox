using System.Collections.Generic;

namespace WebAPI.Dtos
{
    public class PlasticDetailDto : PlasticListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PlasticType { get; set; }
        public int wt { get; set; }
        public int size { get; set; }
        public string Photo { get; set; }
    }
}