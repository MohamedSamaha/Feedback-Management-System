using FeedbackSystem.BusinessLogic.Services;
using FeedbackSystem.Core.Dtos;
using FeedbackSystem.Core.Entities;
using FeedbackSystem.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackSystem.UI.Controllers
{
    [Route("Admin/RequestType")]
    [Authorize(Roles = $"{UserRole.Role_User_Admin}")]
    public class RequestTypeController : Controller
    {
        private readonly IRequestTypeService _requestTypeService;

        public RequestTypeController(IRequestTypeService requestTypeService)
        {
            _requestTypeService = requestTypeService;
        }

        public async Task<IActionResult> Index()
        {
            var allrequestTypes = await _requestTypeService.GetAllRequestTypes();
            return View(allrequestTypes);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(string requestTypeNameEn, string requestTypeNameAr, string activation)
        {
            try
            {
                var requestTypeDto = new RequestTypeDto()
                {
                    NameAr = requestTypeNameAr,
                    NameEn = requestTypeNameEn,
                    Activation = short.Parse(activation)
                };
                var createRequestType = await _requestTypeService.CreateRequestType(requestTypeDto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(int Id, string requestTypeNameInEnglish, string requestTypeNameInArabic, string requestTypeActivation)
        {
            try
            {
                var requestTypeDto = new RequestTypeDto()
                {
                    Id = Id,
                    NameAr = requestTypeNameInArabic,
                    NameEn = requestTypeNameInEnglish,
                    Activation = short.Parse(requestTypeActivation),
                    UpdatedAt = DateTime.UtcNow,
                };
                var createRequestType = await _requestTypeService.UpdateRequestType(requestTypeDto);
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
                await _requestTypeService.DeleteRequestType(Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
