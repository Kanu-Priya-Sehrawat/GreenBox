using System.Threading.Tasks;

namespace WebAPI.Interfaces
{
    public interface IUnitOfWork
    {
        
         IUserRepository UserRepository {get; }

         IPlasticRepository PlasticRepository {get; }

         IPlasticTypeRepository PlasticTypeRepository {get; }
         
         Task<bool> SaveAsync();
    }
}