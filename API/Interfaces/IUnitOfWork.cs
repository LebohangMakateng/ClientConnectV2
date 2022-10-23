using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IUnitOfWork
    {
         IUserRepository UserRepository {get; }
         IMessageRepository MessageRepository {get; }
         IRatingRepository RatingRepository {get; }
         IGigRepository GigRepository {get;}
         Task<bool> Complete();
         bool HasChanges();
    }
}