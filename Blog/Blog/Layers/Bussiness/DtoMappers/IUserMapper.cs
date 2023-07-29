using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Models.Dtos;
using Blog.Models.User;

namespace Blog.Layers.Bussiness.DtoMappers
{
    public interface IUserMapper
    {
        User RegisterDtoToUser(RegisterDto model);
        UserDto ToUserDto(User model);
    }
}
