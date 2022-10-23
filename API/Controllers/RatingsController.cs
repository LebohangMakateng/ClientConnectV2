using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class RatingsController : BaseApiController
    {
         private readonly IUserRepository _userRepository;
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;

        public RatingsController(IUserRepository userRepository, IRatingRepository ratingRepository, 
            IMapper mapper)
        {
            _mapper = mapper;
            _ratingRepository = ratingRepository;
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<ActionResult<RatingDto>> CreateRating(CreateRatingDto createRatingDto)
        {
            var username = User.GetUserName();

            //if (username == createRatingDto.RecipientUsername.ToLower())
            //    return BadRequest("You cannot Rate yourself");

            var sender = await _userRepository.GetUserByUsernameAsync(username);
            var recipient = await _userRepository.GetUserByUsernameAsync(createRatingDto.RecipientUsername);

            Console.Write(createRatingDto.RecipientUsername);

            if (recipient == null) return BadRequest("Not working broer");

            var rating = new Rating
            {
                Sender = sender,
                Recipient = recipient,
                SenderUsername = sender.UserName,
                RecipientUsername = recipient.UserName,
                Content = createRatingDto.Content
            };

            _ratingRepository.AddRating(rating);

            if (await _ratingRepository.SaveAllAsync()) return Ok(_mapper.Map<RatingDto>(rating));

            return BadRequest("Failed to send rating");

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RatingDto>>> GetRatingsForUser([FromQuery] 
            RatingParams ratingParams)
        {
            ratingParams.Username = User.GetUserName();

            var ratings = await _ratingRepository.GetRatingsForUser(ratingParams);

            Response.AddPaginationHeader(ratings.CurrentPage, ratings.PageSize, 
                ratings.TotalCount, ratings.TotalPages);

            return ratings;
        }

        [HttpGet("thread/{username}")]
        public async Task<ActionResult<IEnumerable<RatingDto>>> GetRatingThread(string username)
        {
            var currentUsername = User.GetUserName();

            return Ok(await _ratingRepository.GetRatingThread(currentUsername, username));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRating(int id)
        {
            var username = User.GetUserName();

            var rating = await _ratingRepository.GetRating(id);

            if (rating.Sender.UserName != username && rating.Recipient.UserName != username) 
                return Unauthorized();

            if (rating.Sender.UserName == username) rating.SenderDeleted = true;

            if (rating.Recipient.UserName == username) rating.RecipientDeleted = true;

            if (rating.SenderDeleted && rating.RecipientDeleted) 
                _ratingRepository.DeleteRating(rating);

            if (await _ratingRepository.SaveAllAsync()) return Ok();

            return BadRequest("Problem deleting the rating");
        }

    }
}