using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackSystem.Core.Interfaces.IServices
{
    public interface IDashboardService
    {
        Task<int> GetAllTicketsBySpecificType(long Id = 0);
        Task<int> GetAllTicketsBySpecificRequestType(long Id = 0);
        
        Task<int> GetAllTicketsBySpecificClassification(long Id);
    }
}
