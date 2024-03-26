using FeedbackSystem.Core.Dtos;
using FeedbackSystem.Core.Entities;
using FeedbackSystem.Core.Interfaces.IRepository;
using FeedbackSystem.Core.Interfaces.IServices;
using FeedbackSystem.Core.ViewModels;
using FeedbackSystem.UI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackSystem.UI.Controllers
{
    [Route("Admin/Tickets")]
    [Authorize(Roles = $"{UserRole.Role_User_Admin}")]
    public class FeedbackController : Controller
    {
        private readonly ITicketService _ticketService;
        public FeedbackController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var getAllFeedbacks = await _ticketService.GetAllTickets();
                return View(getAllFeedbacks);
            }
            catch (Exception ex)
            {

                throw;
            }


        }


        [HttpPost("Edit")]
        public async Task Edit(long Id, long responseType, string responseNote)
        {
            try
            {

                var ticketDto = new TicketDto()
                {
                    Id = Id,
                    ResponseTypeId = responseType,
                    ResponseNotes = responseNote
                };
                await _ticketService.UpdateTicket(ticketDto);
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        [HttpPost("Filter")]
        public async Task<IEnumerable<TicketVM>> Filter(int Id)
        {
            try
            {
                var getAllFeedbacks = await _ticketService.GetAllTickets();

                var filteredRequests = getAllFeedbacks.Where(r => r.senderTypeId == Id).ToList();
                return filteredRequests;

            }
            catch (Exception ex)
            {

                throw;
            }


        }
    }
}
