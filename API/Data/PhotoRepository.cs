using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly DataContext _context;
        public PhotoRepository(DataContext context)
        {
            _context = context;
        }
        
        //Adapted from UserRepository.cs GetUserByUsernameAsync()
        public async Task<Photo> GetPhotoById(int id)
        {
            return await _context.Photos
                .IgnoreQueryFilters() //test
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        //adapted from MessageRepository.cs(RemoveConnection();)
        public void RemovePhoto(Photo photo)
        {
            _context.Photos.Remove(photo);
        }
    }
}