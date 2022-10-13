using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using API.Helpers;

namespace API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<UserDto> GetUserAsync(string username, bool IsCurrentUser)
        {
            ////https://docs.microsoft.com/en-us/ef/core/querying/filters

            //var user = User.UserName;

            var query = _context.Users
                .Where(x => x.UserName == username)
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                //.SingleOrDefaultAsync()
                .AsQueryable();
                //.IgnoreQuery

            if(IsCurrentUser)
            {
                //IsCurrentUser: user == username
                query = query.IgnoreQueryFilters();
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<PagedList<UserDto>> GetUsersAsync( UserParams  userParams)
        {
           var query = _context.Users.AsQueryable();

           query = query.Where(u => u.UserName != userParams.CurrentUsername);

           return await PagedList<UserDto>.CreateAsync(query.ProjectTo<UserDto>(_mapper
                .ConfigurationProvider).AsNoTracking() ,
                     userParams.PageNumber, userParams.PageSize);
          
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await _context.Users
            .Include(p => p.Photos)
            .SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
           return await _context.Users
           .Include(p => p.Photos)
           .ToListAsync();
        }

        public void Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}