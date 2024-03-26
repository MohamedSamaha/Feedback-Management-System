using AutoMapper;
using FeedbackSystem.Core.Dtos;
using FeedbackSystem.Core.Entities;
using FeedbackSystem.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FeedbackSystem.UI.Controllers
{
    [Route("Admin/Buildings")]
    [Authorize(Roles = $"{UserRole.Role_User_Admin}")]
    public class BuildingsController : Controller
    {
        private readonly IBuildingService _buildingService;
        public BuildingsController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }

        public async Task<IActionResult> Index()
        {
            var allBuildings = await _buildingService.GetAllBuildings();
            return View(allBuildings);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(string buildingNameEn, string buildingNameAr, string activation)
        {
            try
            {
                var buildingDto = new BuildingDto()
                {
                    NameAr = buildingNameAr,
                    NameEn = buildingNameEn,
                    Activation = short.Parse(activation),
                };
                var createBuilding = await _buildingService.CreateBuilding(buildingDto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(int Id, string buildingNameInEnglish, string buildingNameInArabic, string buildingActivation)
        {
            try
            {
                var buildingDto = new BuildingDto()
                {
                    Id = Id,
                    NameAr = buildingNameInArabic,
                    NameEn = buildingNameInEnglish,
                    Activation = short.Parse(buildingActivation),
                    UpdatedAt = DateTime.UtcNow
                };
                var createBuilding = await _buildingService.UpdateBuilding(buildingDto);
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
                await _buildingService.DeleteBuilding(Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
