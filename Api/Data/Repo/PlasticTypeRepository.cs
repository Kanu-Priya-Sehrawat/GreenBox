using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Data.Repo
{
    public class PlasticTypeRepository : IPlasticTypeRepository
    {
        private readonly DataContext dc;

        public PlasticTypeRepository(DataContext dc)
        {
            this.dc = dc;
        }
        public async Task<IEnumerable<PlasticType>> GetPropertyTypesAsync()
        {
            return await dc.PlasticTypes.ToListAsync();
        }
    }
}