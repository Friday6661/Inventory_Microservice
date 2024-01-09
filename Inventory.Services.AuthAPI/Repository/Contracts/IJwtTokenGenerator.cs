using Inventory.Services.AuthAPI.Models;

namespace Inventory.Services.AuthAPI.Repository.Contracts
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, ICollection<string> roles);
    }
}
