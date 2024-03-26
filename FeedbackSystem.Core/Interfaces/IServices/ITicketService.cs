using FeedbackSystem.Core.Dtos;
using FeedbackSystem.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FeedbackSystem.Core.Interfaces.IServices
{
    public interface ITicketService
    {
        Task<IEnumerable<TicketVM>> GetAllTickets();
        Task<TicketDto> GetTicketById(long Id);
        Task<TicketDto> CreateTicketType(TicketDto ticketDto, List<TicketImagesDto?> ticketImageDto);
        Task<TicketDto> UpdateTicket(TicketDto ticketDto);
        Task DeleteTicket(long Id);
    }
}
