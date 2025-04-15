namespace Application.UseCases.Users.LoginUser
{
    public class LoginUserOutput
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? Document { get; set; }
        public string? Mobile { get; set; }
        public string? Phone { get; set; }

        public string? Username { get; set; }
        public string? Email { get; set; }

        public string? Token { get; set; }
    }
}
