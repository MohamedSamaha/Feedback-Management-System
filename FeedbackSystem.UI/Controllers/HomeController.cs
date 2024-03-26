using FeedbackSystem.Core.Entities;
using FeedbackSystem.Core.Interfaces.IServices;
using FeedbackSystem.UI.Models;
using FeedbackSystem.UI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FeedbackSystem.UI.Controllers
{
    [Authorize(Roles = $"{UserRole.Role_User_Admin}")]
    public class HomeController : Controller
    {
        private readonly IDashboardService _dashboardService;

        public HomeController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public async Task<IActionResult> Index()
        {
            var responseTypeStatus = new ReponseTypeDashboardStatusVM()
            {
                AllTicketsResponses = await _dashboardService.GetAllTicketsBySpecificType(0),
                AllTicketsOfTypeNewRequest = await _dashboardService.GetAllTicketsBySpecificType(1),
                AllTicketsOfTypeProccessingRequest = await _dashboardService.GetAllTicketsBySpecificType(2),
                AllTicketsOfTypeSolvedRequest = await _dashboardService.GetAllTicketsBySpecificType(3),
                AllTicketsOfTypeClosedRequest = await _dashboardService.GetAllTicketsBySpecificType(5),
                AllTicketsOfTypeEngineerDep = await _dashboardService.GetAllTicketsBySpecificType(7),
            };

            var requestTypeStatus = new RequestTypeDashboardStatusVM()
            {
                Suggestion = await _dashboardService.GetAllTicketsBySpecificRequestType(1),
                Complaint = await _dashboardService.GetAllTicketsBySpecificRequestType(2),
                Comment = await _dashboardService.GetAllTicketsBySpecificRequestType(3),
                Request = await _dashboardService.GetAllTicketsBySpecificRequestType(4),
                Other = await _dashboardService.GetAllTicketsBySpecificRequestType(5),
                
            };

            var classification = new ClassificationDashboardStatusVM()
            {
                Cleanliness = await _dashboardService.GetAllTicketsBySpecificClassification(1),
                Maintenance = await _dashboardService.GetAllTicketsBySpecificClassification(2),
                MaterialShortage = await _dashboardService.GetAllTicketsBySpecificClassification(3),
                FoodAndDrinksQuality = await _dashboardService.GetAllTicketsBySpecificClassification(4),
                LostItems = await _dashboardService.GetAllTicketsBySpecificClassification(5),
                Other = await _dashboardService.GetAllTicketsBySpecificClassification(6),
            };
            var ticketVM = new DashboardStatusViewModel()
            {
                ReponseTypeDashboardStatus = responseTypeStatus,
                RequestTypeDashboardStatus = requestTypeStatus,
                ClassificationDashboardStatus = classification
            };
            return View(ticketVM);
        }

        [HttpPost]
        // Function To Change Localization and Culture Language.
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
