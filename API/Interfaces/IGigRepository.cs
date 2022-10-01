using System.Threading.Tasks;
using API.Entities;
using API.Helpers;

namespace API.Interfaces
{
    public interface IGigRepository
    {
        void Update(int id);
        void Delete(int id);

        void Add(Gig gig);
        
        Task<PagedList<Gig>> GetGigsByUserAsync(string username, GigParams expenseParams);
        Task<Gig> GetGigByIdAsync(int id);
    }
}