using System.Threading.Tasks;
using WebAPI.Data.Repo;
using WebAPI.Interfaces;

namespace WebAPI.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dc;

        public UnitOfWork(DataContext dc)
        {
            this.dc = dc;
        }
        
        public IUserRepository UserRepository =>         
            new UserRepository(dc);

        public IPlasticTypeRepository PlasticTypeRepository =>         
            new PlasticTypeRepository(dc);

        public IPlasticRepository PlasticRepository => 
            new PlasticRepository(dc);



        public async Task<bool> SaveAsync()
        {
           return await dc.SaveChangesAsync() > 0;
        }
    }
}