using System.ComponentModel.DataAnnotations;

namespace Inventory.Services.AuthAPI.Models.Dto
{
    public class RegistrationRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
