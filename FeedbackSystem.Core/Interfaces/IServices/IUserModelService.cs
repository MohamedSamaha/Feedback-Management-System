using FeedbackSystem.Core.Dtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackSystem.Core.Interfaces.IServices
{
    public interface IUserModelService
    {
        Task<IEnumerable<UserModelDto>> GetAllUsersModelAsync();
        Task<UserModelDto> GetUserModelById(string Id);
        Task<UserModelDto> CreateUserModel(UserModelDto userModelDto, string Password, string role);
        Task<UserModelDto> UpdateUserModel(UserModelDto userModelDto, string newRole);
        Task<IdentityResult> DeleteUserModel(string Id);
    }
}
