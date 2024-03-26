using FeedbackSystem.BusinessLogic.Services;
using FeedbackSystem.Core.Dtos;
using FeedbackSystem.Core.Entities;
using FeedbackSystem.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackSystem.UI.Controllers
{
    [Route("Admin/Users")]
    [Authorize(Roles = $"{UserRole.Role_User_Admin}")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserModelService _userModelService;

        public UserController(IUserService userService, IUserModelService userModelService)
        {
            _userService = userService;
            _userModelService = userModelService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userModelService.GetAllUsersModelAsync();
            return View(users);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(string username, string email, string password, string role, string activation)
        {
            try
            {
                var userDto = new UserModelDto()
                {
                    Fullname = username,
                    NormalizedEmail = email,
                    NormalizedUserName = email,
                    UserName = email,
                    Email = email,
                    UserRole = role,
                    Activation = short.Parse(activation)
                };
                var createRequestType = await _userModelService.CreateUserModel(userDto, password, role);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(string Id, string username, string email, string role, string activation)
        {
            try
            {
                
                var userDto = new UserModelDto()
                {
                    Id = Id,
                    Fullname = username,
                    Email = email,
                    UserRole = role,
                    Activation = short.Parse(activation),
                    UpdatedAt = DateTime.UtcNow,
                };
                await _userModelService.UpdateUserModel(userDto, role);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(string Id)
        {
            try
            {
                await _userModelService.DeleteUserModel(Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
