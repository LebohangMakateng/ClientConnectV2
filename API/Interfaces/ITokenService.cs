using API.Entities;
using Microsoft.AspNetCore.Identity;

namespace API.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}   