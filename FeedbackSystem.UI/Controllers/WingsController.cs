using AutoMapper;
using FeedbackSystem.BusinessLogic.Services;
using FeedbackSystem.Core.Dtos;
using FeedbackSystem.Core.Entities;
using FeedbackSystem.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackSystem.UI.Controllers
{
    [Route("Admin/Wings")]
    [Authorize(Roles = $"{UserRole.Role_User_Admin}")]
    public class WingsController : Controller
    {
        private readonly IWingsService _wingService;
        private readonly IMapper _mapper;
        public WingsController(IWingsService wingService, IMapper mapper)
        {
            _wingService = wingService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var allWings = await _wingService.GetAllWings();
            return View(allWings);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(string wingNameEn, string wingNameAr, string activation)
        {
            try
            {
                var wingDto = new WingDto()
                {
                    NameAr = wingNameAr,
                    NameEn = wingNameEn,
                    Activation = short.Parse(activation),
                };
                var createWing = await _wingService.CreateWing(wingDto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(int Id, string wingNameInEnglish, string wingNameInArabic, string wingActivation)
        {
            try
            {
                var wingDto = new WingDto()
                {
                    Id = Id,
                    NameAr = wingNameInArabic,
                    NameEn = wingNameInEnglish,
                    Activation = short.Parse(wingActivation),
                    UpdatedAt = DateTime.UtcNow
                };
                var createWing = await _wingService.UpdateWing(wingDto);
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
                await _wingService.DeleteWing(Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
