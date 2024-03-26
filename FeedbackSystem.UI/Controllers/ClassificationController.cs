using AutoMapper;
using FeedbackSystem.BusinessLogic.Services;
using FeedbackSystem.Core.Dtos;
using FeedbackSystem.Core.Entities;
using FeedbackSystem.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackSystem.UI.Controllers
{
    [Route("Admin/Classification")]
    [Authorize(Roles = $"{UserRole.Role_User_Admin}")]
    public class ClassificationController : Controller
    {
        private readonly IClassificationService _classificationService;
        public ClassificationController(IClassificationService classificationService)
        {
            _classificationService = classificationService;
        }

        public async Task<IActionResult> Index()
        {
            var allClassification = await _classificationService.GetAllClassifications();
            return View(allClassification);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(string classificationNameEn, string classificationNameAr, string activation)
        {
            try
            {
                var classificationDto = new ClassificationDto()
                {
                    NameAr = classificationNameAr,
                    NameEn = classificationNameEn,
                    Activation = short.Parse(activation),
                };
                var createclassification = await _classificationService.CreateClassification(classificationDto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(int Id, string classificationNameInEnglish, string classificationNameInArabic, string classificationActivation)
        {
            try
            {
                var classificationDto = new ClassificationDto()
                {
                    Id = Id,
                    NameAr = classificationNameInArabic,
                    NameEn = classificationNameInEnglish,
                    Activation = short.Parse(classificationActivation),
                    UpdatedAt = DateTime.UtcNow
                };
                var createclassification = await _classificationService.UpdateClassification(classificationDto);
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
                await _classificationService.DeleteClassification(Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
