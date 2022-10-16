using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IUnitOfWork
    {
         IUserRepository UserRepository {get; }
         IMessageRepository MessageRepository {get; }
         IGigRepository GigRepository {get;}
         Task<bool> Complete();
         bool HasChanges();
    }
}