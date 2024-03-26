using FeedbackSystem.BusinessLogic.Services;
using FeedbackSystem.Core.Dtos;
using FeedbackSystem.Core.Entities;
using FeedbackSystem.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackSystem.UI.Controllers
{
    [Route("Admin/Floor")]
    [Authorize(Roles = $"{UserRole.Role_User_Admin}")]
    public class FloorController : Controller
    {
        private readonly IFloorNumberService _floorNumberService;

        public FloorController(IFloorNumberService floorNumberService)
        {
            _floorNumberService = floorNumberService;
        }

        public async Task<IActionResult> Index()
        {
            var allFloors = await _floorNumberService.GetAllFloorNumbers();
            return View(allFloors);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(string floorNameEn, string floorNameAr, string activation)
        {
            try
            {
                var floorDto = new FloorNumberDto()
                {
                    NameAr = floorNameAr,
                    NameEn = floorNameEn,
                    Activation = short.Parse(activation),
                };
                var createFloor = await _floorNumberService.CreateFloorNumber(floorDto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(int Id, string floorNameInEnglish, string floorNameInArabic, string floorActivation)
        {
            try
            {
                var floorDto = new FloorNumberDto()
                {
                    Id = Id,
                    NameAr = floorNameInArabic,
                    NameEn = floorNameInEnglish,
                    Activation = short.Parse(floorActivation),
                    UpdatedAt = DateTime.UtcNow
                };
                var createFloor = await _floorNumberService.UpdateFloorNumber(floorDto);
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
                await _floorNumberService.DeleteFloorNumberDto(Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
