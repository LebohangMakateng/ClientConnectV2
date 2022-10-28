using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class RatingRepository : IRatingRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public RatingRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public void AddRating(Rating rating)
        {
            _context.Ratings.Add(rating);
        }

        public void DeleteRating(Rating rating)
        {
            _context.Ratings.Remove(rating);
        }

        public async Task<Rating> GetRating(int id)
        {
            return await _context.Ratings
                .Include(u => u.Sender)
                .Include(u => u.Recipient)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PagedList<RatingDto>> GetRatingsForUser(RatingParams ratingParams)
        {
            var query = _context.Ratings
                .OrderByDescending(m => m.RatingSent)
                .AsQueryable();

            query = ratingParams.Container switch
            {
                "Inbox" => query.Where(u => u.Recipient.UserName == ratingParams.Username 
                    && u.RecipientDeleted == false),
                "Outbox" => query.Where(u => u.Sender.UserName == ratingParams.Username
                    && u.SenderDeleted == false),
                _ => query.Where(u => u.Recipient.UserName ==
                    ratingParams.Username && u.RecipientDeleted == false && u.DateRead == null)
            };

            var ratings = query.ProjectTo<RatingDto>(_mapper.ConfigurationProvider);

            return await PagedList<RatingDto>.CreateAsync(ratings, ratingParams.PageNumber, ratingParams.PageSize);

        }

        public async Task<IEnumerable<RatingDto>> GetRatingThread(string currentUsername, 
            string recipientUsername)
        {
            var ratings = await _context.Ratings.Where(e => e.Recipient.UserName == recipientUsername).OrderBy(m => m.RatingSent).ToListAsync();
            return _mapper.Map<IEnumerable<RatingDto>>(ratings);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}


