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

        Task<PagedList<Gig>> GetAllGigsAsync(GigParams gigParams);

        Task<PagedList<Gig>> GetGigsByLocatioAsync(string username, GigParams expenseParams);

        Task<PagedList<Gig>> GetGigsByProfessionAsync(string Expertise, GigParams gigParams);
        Task<Gig> GetGigByIdAsync(int id);
    }
}