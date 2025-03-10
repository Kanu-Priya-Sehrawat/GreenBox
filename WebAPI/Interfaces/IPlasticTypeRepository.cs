using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface IPlasticTypeRepository
    {
         Task<IEnumerable<PlasticType>> GetFurnishingTypesAsync();
    }
}