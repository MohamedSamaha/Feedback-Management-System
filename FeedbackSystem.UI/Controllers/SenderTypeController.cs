using FeedbackSystem.BusinessLogic.Services;
using FeedbackSystem.Core.Dtos;
using FeedbackSystem.Core.Entities;
using FeedbackSystem.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackSystem.UI.Controllers
{
    [Route("Admin/SenderType")]
    [Authorize(Roles = $"{UserRole.Role_User_Admin}")]
    public class SenderTypeController : Controller
    {
        private readonly ISenderTypeService _senderTypeService;

        public SenderTypeController(ISenderTypeService senderTypeService)
        {
            _senderTypeService = senderTypeService;
        }

        public async Task<IActionResult> Index()
        {
            var allSenders = await _senderTypeService.GetAllSenderTypes();
            return View(allSenders);
        }
        
        [HttpPost("Create")]
        public async Task<IActionResult> Create(string senderTypeNameEn, string senderTypeNameAr, string activation)
        {
            try
            {
                var senderTypeDto = new SenderTypeDto()
                {
                    NameAr = senderTypeNameAr,
                    NameEn = senderTypeNameEn,
                    Activation = short.Parse(activation)
                };
                var createSenderType = await _senderTypeService.CreateSenderType(senderTypeDto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(int Id, string senderTypeNameInEnglish, string senderTypeNameInArabic, string senderTypeActivation)
        {
            try
            {
                var senderTypeDto = new SenderTypeDto()
                {
                    Id = Id,
                    NameAr = senderTypeNameInArabic,
                    NameEn = senderTypeNameInEnglish,
                    Activation = short.Parse(senderTypeActivation),
                    UpdatedAt = DateTime.UtcNow
                };
                var createRequestType = await _senderTypeService.UpdateSenderType(senderTypeDto);
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
                await _senderTypeService.DeleteSenderType(Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
