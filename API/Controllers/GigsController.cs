using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class GigsController:BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public GigsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GigDto>>> GetGigs([FromQuery] GigParams gigParams)
        {
            var username = User.GetUserName();

            var gigs = await _unitOfWork.GigRepository.GetGigsByUserAsync(username, gigParams);

            var gigsToReturn = _mapper.Map<IEnumerable<GigDto>>(gigs);

            Response.AddPaginationHeader(gigs.CurrentPage, gigs.PageSize,
                gigs.TotalCount, gigs.TotalPages);

            return Ok(gigsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GigDto>> GetGig(int id)
        {
            var Gig = await _unitOfWork.GigRepository.GetGigByIdAsync(id);

            return _mapper.Map<GigDto>(Gig);
        }

        [HttpPost]
        public async Task<ActionResult> Add(Gig _gig)
        {
            var username = User.GetUserName();
            var Gig = new Gig()
            {
                Date = _gig.Date,
                UserName = username,
                Title = _gig.Title,
                Description = _gig.Description,
                Expertise = _gig.Expertise,
                Progress = _gig.Progress,
                TaskRate = _gig.TaskRate,
                RateType = _gig.RateType,
                Location = _gig.Location

            };

            _unitOfWork.GigRepository.Add(Gig);

            if (await _unitOfWork.Complete()) return NoContent();

            return BadRequest("Failed to add Gig.");

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, GigUpdateDto GigUpdateDto)
        {
            var username = User.GetUserName();
            var gig = await _unitOfWork.GigRepository.GetGigByIdAsync(id);

            _mapper.Map(GigUpdateDto, gig);

            _unitOfWork.GigRepository.Update(gig.Id);

            if (await _unitOfWork.Complete()) return NoContent();

            return BadRequest("Failed to update the Gig.");

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var gig = await _unitOfWork.GigRepository.GetGigByIdAsync(id);

            _unitOfWork.GigRepository.Delete(gig.Id);

            if (await _unitOfWork.Complete()) return NoContent();

            return BadRequest("Failed to delete the Gig.");
        }
    }
}