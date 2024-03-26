using FeedbackSystem.Core.Interfaces;
using FeedbackSystem.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackSystem.BusinessLogic.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DashboardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> GetAllTicketsBySpecificClassification(long Id)
        {
            var allTicketsClassification = await _unitOfWork.Tickets.EntityWithEagerLoad(t => t.ClassificationId == Id, new string[] { });
            return allTicketsClassification.Count();
        }
        public async Task<int> GetAllTicketsBySpecificRequestType(long Id)
        {
            var allTicketsRequest = await _unitOfWork.Tickets.EntityWithEagerLoad(t => t.RequestTypeId == Id, new string[] { });
            return allTicketsRequest.Count();
        }

        public async Task<int> GetAllTicketsBySpecificType(long Id = 0)
        {
            if (Id == 0)
            {
                var allTicketsReponse = await _unitOfWork.Tickets.EntityWithEagerLoad(t => true, new string[] { });
                return allTicketsReponse.Count();
            }
            else
            {
                var allTicketsReponse = await _unitOfWork.Tickets.EntityWithEagerLoad(t => t.ResponseTypeId == Id, new string[] { });
                return allTicketsReponse.Count();

            }

        }
    }
}
