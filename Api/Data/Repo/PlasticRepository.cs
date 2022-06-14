using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Data.Repo
{
    public class PlasticRepository : IPlasticRepository
    {
        private readonly DataContext dc;

        public PlasticRepository(DataContext dc)
        {
            this.dc = dc;
        }
        public void AddProperty(Plastic plastic)
        {
            dc.Plastic.Add(plastic);
        }

        public void DeleteProperty(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Plastic>> GetPropertiesAsync(int userId)
        {
            var properties = await dc.Plastic
            .Include(p => p.PlasticType)
            .Include(p => p.Photos)
            .Where(p=> p.PostedBy == userId)
            .ToListAsync();

            return properties;
        }

        public async Task<Plastic> GetPropertyDetailAsync(int id)
        {
            var properties = await dc.Plastic
            .Include(p => p.PlasticType)
            .Include(p => p.Photos)
            .Where(p => p.Id == id)
            .FirstAsync();

            return properties;
        }

        public async Task<Plastic> GetPropertyByIdAsync(int id)
        {
            var properties = await dc.Plastic
            .Include(p => p.Photos)
            .Where(p => p.Id == id)
            .FirstAsync();

            return properties;
        }


    }
}