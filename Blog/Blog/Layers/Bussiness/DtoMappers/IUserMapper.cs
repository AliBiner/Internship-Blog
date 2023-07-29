using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Layers.Models.Dtos;
using Blog.Models.Dtos;
using Blog.Models.User;

namespace Blog.Layers.Bussiness.DtoMappers
{
    public interface IUserMapper
    {
        User SigninDtoToUser(SigninDto model);
        UserInformationDto ForUserInformationPageDto(User model);
        public User ForUpdateUserInformationPageDtoTo(UpdateUserInformationDto dto,User user);
    }
}
