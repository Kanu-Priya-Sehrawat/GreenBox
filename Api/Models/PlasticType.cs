using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class PlasticType: BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}