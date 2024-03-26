using FeedbackSystem.Core.Dtos;
using FeedbackSystem.Core.Entities;
using FeedbackSystem.Core.Interfaces.IServices;
using FeedbackSystem.UI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackSystem.UI.Controllers
{
    /*[Authorize(Roles = $"{UserRole.Role_User_Admin}, {UserRole.Role_User_User}")]*/
    [Authorize(Roles = $"{UserRole.Role_User_Admin}")]
    [Route("Admin/Places")]
    public class PlaceController : Controller
    {
        private readonly IPlaceService _placeService;

        public PlaceController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        public async Task<IActionResult> Index()
        {
            var getAllPlaces = await _placeService.GetAllPlaces();
            return View(getAllPlaces);
        }
        [HttpPost("Create")]
        public async Task Create(PlaceVM placeVM)
        {
            var placeDto = new PlaceDto()
            {
                BuildingId = placeVM.building,
                PlaceTypeId = placeVM.placeType,
                FloorNumberId = placeVM.floorNumber,
                WingId = placeVM.wing,
                Code = placeVM.placeCode,
                Description = placeVM.placeDescription,
                Activation = placeVM.activation
            };
            await _placeService.CreatePlace(placeDto);
        }

        [HttpPost("Edit")]
        public async Task Edit(PlaceVM placeVM)
        {
            try
            {
                if (placeVM.Id != null || placeVM.Id == 0)
                {
                    var placeDto = new PlaceDto()
                    {
                        Id = placeVM.Id,
                        BuildingId = placeVM.building,
                        PlaceTypeId = placeVM.placeType,
                        FloorNumberId = placeVM.floorNumber,
                        WingId = placeVM.wing,
                        Code = placeVM.placeCode,
                        Description = placeVM.placeDescription,
                        Activation = placeVM.activation,
                        UpdatedAt = DateTime.Now
                    };
                    await _placeService.UpdatePlace(placeDto);

                }

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
                await _placeService.DeletePlace(Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
