using Blog.Layers.Models.Dtos;
using Blog.Layers.Models.Dtos.UserDtos;
using Blog.Models.Entities;

namespace Blog.Layers.Bussiness.DtoMappers
{
    public interface IUserMapper
    {
        User SigninDtoToUser(SigninDto model);
        UserInformationDto ForUserInformationPageDto(User model);
        public User ForUpdateUserInformationPageDtoTo(UpdateUserInformationDto dto,User user);

        AllUserForAccountManage toAllUserForAccountManage(User u);
    }
}
