using AutoMapper;
using FeedbackSystem.BusinessLogic.Extentions;
using FeedbackSystem.Core.Dtos;
using FeedbackSystem.Core.Entities;
using FeedbackSystem.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackSystem.BusinessLogic.Services
{
    public class UserModelService : IUserModelService
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public UserModelService(UserManager<UserModel> userManager, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserModelDto> CreateUserModel(UserModelDto userModelDto, string Password, string role)
        {
            try
            {
                var userActual = await _userManager.GetCurrentUserAsync(_httpContextAccessor.HttpContext);

                var user = new UserModel
                {
                    UserName = userModelDto.Email,
                    Email = userModelDto.Email,
                    NormalizedEmail = userModelDto.Email,
                    NormalizedUserName = userModelDto.Email,
                    Fullname = userModelDto.Fullname,
                    Activation = 1,
                    CreatedAt = DateTime.Now,
                    UserRole = role,
                    CreatedBy = userActual.Id,


                };

                var result = await _userManager.CreateAsync(user, Password);
                if (result.Succeeded)
                {
                    // User created successfully, assign the role
                    await _userManager.AddToRoleAsync(user, role);
                }
                

                return userModelDto;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<IdentityResult> DeleteUserModel(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
            {
                // Handle the case where user is not found
                return IdentityResult.Failed(new IdentityError { Description = $"User with ID '{Id}' not found." });
            }
            var actualUser = await _userManager.GetCurrentUserAsync(_httpContextAccessor.HttpContext);
            user.DeletedBy = actualUser.Id;
            user.DeletedAt = DateTime.Now;
            user.Activation = 0;
            return await _userManager.UpdateAsync(user);
        }

        public async Task<IEnumerable<UserModelDto>> GetAllUsersModelAsync()
        {

            var usersModel = await _userManager.Users.ToListAsync();
            var mappedUser = usersModel.Where(u => u.DeletedAt == null);
            return _mapper.Map<IEnumerable<UserModelDto>>(mappedUser);
        }

        public async Task<UserModelDto> GetUserModelById(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);

            if (user.DeletedAt == null)
            {
                return _mapper.Map<UserModelDto>(user);
            }
            else
            {
                return new UserModelDto();
            }
        }
        public async Task<UserModelDto> UpdateUserModel(UserModelDto userModelDto, string newRole)
        {
            var user = await _userManager.FindByIdAsync(userModelDto.Id);
            if (user == null)
            {
                throw new ApplicationException($"User with ID '{userModelDto.Id}' not found.");
            }
            if (user.DeletedAt == null)
            {
                var currentRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, currentRoles.ToArray());
                await _userManager.AddToRoleAsync(user, newRole);
                var actualUser = await _userManager.GetCurrentUserAsync(_httpContextAccessor.HttpContext);
                user.Email = userModelDto.Email;
                user.Fullname = userModelDto.Fullname;
                user.Activation = userModelDto.Activation;
                user.UpdatedAt = userModelDto.UpdatedAt;
                user.UserRole = userModelDto.UserRole;
                user.UserName = userModelDto.Email;
                user.NormalizedEmail = userModelDto.Email;
                user.NormalizedUserName = userModelDto.Email;
                user.UpdatedAt = DateTime.Now;
                user.UpdatedBy = actualUser.Id;
                await _userManager.UpdateAsync(user);
                return userModelDto;
            }
            else
            {
                return new UserModelDto();
            }
            
        }

    }
}
