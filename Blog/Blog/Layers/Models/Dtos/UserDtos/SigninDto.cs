

namespace Blog.Layers.Models.Dtos
{
    public class SigninDto : BaseDto
    {
        public string Name { get; set; }
        public string? MiddleName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PasswordHash { get; set; }
    }
}