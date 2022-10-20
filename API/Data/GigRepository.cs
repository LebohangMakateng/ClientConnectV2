using System;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class GigRepository: IGigRepository
    {
        private readonly DataContext _context;
        public GigRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Gig gig)
        {
            if (gig != null)
            {
                _context.Gigs.Add(gig);
            }
        }

        public void Delete(int id)
        {
            var gig = _context.Gigs.FirstOrDefault(e => e.Id == id);
            if (gig != null)
            {
                _context.Gigs.Remove(gig);
            }
        }

        public async Task<Gig> GetGigByIdAsync(int id)
        {
            return await _context.Gigs.FindAsync(id);
        }

        public async Task<PagedList<Gig>> GetGigsByUserAsync(string username, GigParams gigParams)
        {
            var query = _context.Gigs.Where(e => e.UserName == username).AsNoTracking();

            var minDate = DateTime.Today.AddMonths(-1);
            if (gigParams.Filter)
            {
                query = query.Where(e => DateTime.Compare(e.Date, minDate) > 0);
            }
            return await PagedList<Gig>.CreateAsync(query, gigParams.PageNumber, gigParams.PageSize);
        }

        public async Task<PagedList<Gig>> GetAllGigsAsync(GigParams gigParams)
        {
            var query = _context.Gigs.AsQueryable();

            var minDate = DateTime.Today.AddMonths(-1);
            
             if (gigParams.Filter)
            {
                query = query.Where(e => DateTime.Compare(e.Date, minDate) > 0);
            }
            return await PagedList<Gig>.CreateAsync(query, gigParams.PageNumber, gigParams.PageSize);
        }

        public async Task<PagedList<Gig>> SearchGigsAsync(string gigtitle, GigParams gigParams)
        {
            //var query = _context.Gigs.AsQueryable();

            //query = query.Where(e => e.Title.ToLower() == "plumber");

            var query = _context.Gigs.Where(e => e.Title.ToLower().Contains(gigtitle) || e.Description.ToLower().Contains(gigtitle));
            
            return await PagedList<Gig>.CreateAsync(query, gigParams.PageNumber, gigParams.PageSize);
        }

         public async Task<PagedList<Gig>> GetGigsByLocatioAsync(string location, GigParams gigParams)
        {
             var query = _context.Gigs.Where(e => e.Location == location).AsNoTracking();

             var minDate = DateTime.Today.AddMonths(-1);
            if (gigParams.Filter)
            {
                query = query.Where(e => DateTime.Compare(e.Date, minDate) > 0);
            }
            return await PagedList<Gig>.CreateAsync(query, gigParams.PageNumber, gigParams.PageSize);
        }

        public async Task<PagedList<Gig>> GetGigsByProfessionAsync(string Expertise, GigParams gigParams)
        {
             var query = _context.Gigs.Where(e => e.Expertise == Expertise).AsNoTracking();
             //var gig = _context.Gigs.FirstOrDefault(e => e.Id == id);

             var minDate = DateTime.Today.AddMonths(-1);
            if (gigParams.Filter)
            {
                query = query.Where(e => DateTime.Compare(e.Date, minDate) > 0);
            }
            return await PagedList<Gig>.CreateAsync(query, gigParams.PageNumber, gigParams.PageSize);
        }

        public void Update(int id)
        {
            var gig = _context.Gigs.FirstOrDefault(e => e.Id == id);
            if (gig != null)
            {
                _context.Entry(gig).State = EntityState.Modified;
            }
        }      
    }
}