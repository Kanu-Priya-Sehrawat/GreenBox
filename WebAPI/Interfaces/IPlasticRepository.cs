using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface IPlasticRepository
    {
        Task<IEnumerable<Plastic>> GetPropertiesAsync(int sellRent);
        Task<Plastic> GetPropertyDetailAsync(int id);
        Task<Plastic> GetPropertyByIdAsync(int id);
        void AddProperty(Plastic plastic);
        void DeleteProperty(int id);
    }
}