using AutoMapper;
using FeedbackSystem.BusinessLogic.Services;
using FeedbackSystem.Core.Dtos;
using FeedbackSystem.Core.Entities;
using FeedbackSystem.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackSystem.UI.Controllers
{
    [Route("Admin/PlaceType")]
    [Authorize(Roles = $"{UserRole.Role_User_Admin}")]
    public class PlaceTypeController : Controller
	{
		private readonly IPlaceTypeService _placeTypeService;

        public PlaceTypeController(IPlaceTypeService placeTypeService)
        {
            _placeTypeService = placeTypeService;
        }
        public async Task<IActionResult> Index()
		{
            var allPlaceTypes = await _placeTypeService.GetAllPlaceType();
            return View(allPlaceTypes);
		}

        [HttpPost("Create")]
        public async Task<IActionResult> Create(string placeTypeNameEn, string placeTypeNameAr, string activation)
        {
            try
            {
                var placeTypeDto = new PlaceTypeDto()
                {
                    NameAr = placeTypeNameAr,
                    NameEn = placeTypeNameEn,
                    Activation = short.Parse(activation)
                };
                var createplaceType = await _placeTypeService.CreatePlaceType(placeTypeDto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(int Id, string placeTypeNameInEnglish, string placeTypeNameInArabic, string placeTypeActivation)
        {
            try
            {
                var placeTypeDto = new PlaceTypeDto()
                {
                    Id = Id,
                    NameAr = placeTypeNameInArabic,
                    NameEn = placeTypeNameInEnglish,
                    Activation = short.Parse(placeTypeActivation),
                    UpdatedAt = DateTime.UtcNow
                };
                var updateplaceType = await _placeTypeService.UpdatePlaceType(placeTypeDto);
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
                await _placeTypeService.DeletePlaceType(Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
