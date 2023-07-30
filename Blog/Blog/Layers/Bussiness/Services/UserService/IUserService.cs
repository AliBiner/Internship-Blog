
using Blog.Layers.Models.Dtos;

namespace Blog.Layers.Bussiness.Services.EntryService
{
    public interface IUserService
    {
        public string UpdatePasswordByEmail(UpdatePasswordDto dto, string email);
        public string Update(UpdateUserInformationDto dto , string email);
        public UserInformationDto GetUserByEmail(string email);
        public string Login(LoginDto d);

        public void Logout();

        public string Signin(SigninDto d);


    }
}
