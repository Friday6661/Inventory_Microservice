using Inventory.Services.AuthAPI.Models.Dto;
using static Inventory.Services.AuthAPI.Models.Response;

namespace Inventory.Services.AuthAPI.Repository.Contracts
{
    public interface IAuth
    {
        Task<GeneralResponse> Register(RegistrationRequestDto registrationRequestDto);
        Task<LoginResponse> Login(LoginRequestDto loginRequestDto);
        Task<GeneralResponse> AssignRole(RegistrationRequestDto registrationRequestDto);
    }
}
