using Inventory.Services.AuthAPI.Models.Dto;

namespace Inventory.Services.AuthAPI.Models
{
    public class Response
    {
        public record class GeneralResponse(bool Flag, string Message);
        public record class LoginResponse(bool Flag, UserDto User, string Token, string Message);
    }
}
