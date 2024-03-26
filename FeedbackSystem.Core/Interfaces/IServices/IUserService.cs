using FeedbackSystem.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackSystem.Core.Interfaces.IServices
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsers();
        Task<UserDto> GetUserById(long Id);
        Task<UserDto> CreateUser(UserDto userDto);
        Task<UserDto> UpdateUser(UserDto userDto);
        Task DeleteUser(long Id);
    }
}
