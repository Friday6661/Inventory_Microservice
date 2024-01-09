using Inventory.Services.AuthAPI.Data;
using Inventory.Services.AuthAPI.Models;
using Inventory.Services.AuthAPI.Models.Dto;
using Inventory.Services.AuthAPI.Repository.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static Inventory.Services.AuthAPI.Models.Response;

namespace Inventory.Services.AuthAPI.Repository.Implementations
{
    public class AuthRepository : IAuth
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
                        RoleManager<IdentityRole> roleManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            _context = context;
            _jwtTokenGenerator = jwtTokenGenerator;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<GeneralResponse> AssignRole(RegistrationRequestDto model)
        {
            var assignRoleTrue = await IsAssignRole(model.Email, model.Role);
            if (!assignRoleTrue)
            {
                return new GeneralResponse(false, "Assign role failed");
            }
            return new GeneralResponse(true, "Assign role succeeded");
        }
        private async Task<bool> IsAssignRole(string email, string roleName)
        {
            var user = await _context.ApplicationUsers.Where(u => u.Email == email).FirstOrDefaultAsync();
            if (user is not null)
            {
                if (!await _roleManager.RoleExistsAsync(roleName))
                {
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
                await _userManager.AddToRoleAsync(user, roleName);
                return true;
            }
            return false;
        }
        public async Task<LoginResponse> Login(LoginRequestDto loginRequestDto)
        {
            var user = await _context.ApplicationUsers.Where(u => u.UserName == loginRequestDto.UserName).FirstOrDefaultAsync();
            if (user is null) return new LoginResponse(false, null!, null!, "User not found");
            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);
            
            if (user is null || isValid == false)
            {
                return new LoginResponse(false, null!, null!, "Invalid user or password");
            }

            var roles = await _userManager.GetRolesAsync(user);
            var token = _jwtTokenGenerator.GenerateToken(user, roles);

            UserDto userDto = new UserDto()
            {
                Email = user.Email,
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
            };

            return new LoginResponse(true, userDto, token, "Login success");
        }

        public async Task<GeneralResponse> Register(RegistrationRequestDto registrationRequestDto)
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserName = registrationRequestDto.Email,
                Email = registrationRequestDto.Email,
                FirstName = registrationRequestDto.FirstName,
                LastName = registrationRequestDto.LastName,
                PhoneNumber = registrationRequestDto.PhoneNumber,
            };

            try
            {
                var result = await _userManager.CreateAsync(user, registrationRequestDto.Password);
                if (result.Succeeded)
                {
                    var userToReturn = await _context.ApplicationUsers
                                                .Where(u => u.UserName == registrationRequestDto.Email)
                                                .FirstOrDefaultAsync();
                    UserDto userDto = new UserDto()
                    {
                        Email = userToReturn.Email,
                        Id = userToReturn.Id,
                        FirstName = userToReturn.FirstName,
                        LastName = userToReturn.LastName,
                        PhoneNumber = userToReturn.PhoneNumber
                    };
                    return new GeneralResponse(true, "Register success");
                }
                else
                {
                    return new GeneralResponse(false, $"{result.Errors.FirstOrDefault().Description}");
                }
            }
            catch (Exception ex)
            {
                return new GeneralResponse(false, $"{ex}");
            }
        }
    }
}
