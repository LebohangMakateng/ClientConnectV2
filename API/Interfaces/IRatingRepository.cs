using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Helpers;

namespace API.Interfaces
{
    public interface IRatingRepository
    {
        void AddRating(Rating rating);
        void DeleteRating(Rating rating);
        Task<Rating> GetRating(int id);
        Task<PagedList<RatingDto>> GetRatingsForUser(RatingParams ratingParams);
        Task<IEnumerable<RatingDto>> GetRatingThread(string currentUsername, string recipientUsername);
        Task<bool> SaveAllAsync();
    }
}