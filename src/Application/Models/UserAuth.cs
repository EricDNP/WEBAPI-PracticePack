using Domain.Enums;

namespace Application.Models
{
    public class UserAuth
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public UserRole Role { get; set; }
    }
}
