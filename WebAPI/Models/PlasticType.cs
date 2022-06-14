using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class PlasticType: BaseEntity
    {
        public int PlasticTypeId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}