using FeedbackSystem.BusinessLogic.Services;
using FeedbackSystem.Core.Dtos;
using FeedbackSystem.Core.Entities;
using FeedbackSystem.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackSystem.UI.Controllers
{
    [Route("Admin/ResponseType")]
    [Authorize(Roles = $"{UserRole.Role_User_Admin}")]
    public class ResponseController : Controller
    {
        private readonly IResponseTypeService _responseTypeService;

        public ResponseController(IResponseTypeService responseTypeService)
        {
            _responseTypeService = responseTypeService;
        }

        public async Task<IActionResult> Index()
        {
            var allRespone = await _responseTypeService.GetAllResponseType();
            return View(allRespone);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(string responseTypeNameEn, string responseTypeNameAr, string activation)
        {
            try
            {
                var responseTypeDto = new ResponseTypeDto()
                {
                    NameAr = responseTypeNameAr,
                    NameEn = responseTypeNameEn,
                    Activation = short.Parse(activation)
                };
                var createResponseType = await _responseTypeService.CreateResponseType(responseTypeDto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(int Id, string responseTypeNameInEnglish, string responseTypeNameInArabic, string responseTypeActivation)
        {
            try
            {
                var responseTypeDto = new ResponseTypeDto()
                {
                    Id = Id,
                    NameAr = responseTypeNameInArabic,
                    NameEn = responseTypeNameInEnglish,
                    Activation = short.Parse(responseTypeActivation),
                    UpdatedAt = DateTime.UtcNow
                };
                var createResponseType = await _responseTypeService.UpdateResponseType(responseTypeDto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                await _responseTypeService.DeleteResponseType(Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw;
            }
        }


    }
}
