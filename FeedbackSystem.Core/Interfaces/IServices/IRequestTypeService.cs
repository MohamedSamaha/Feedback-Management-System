using FeedbackSystem.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackSystem.Core.Interfaces.IServices
{
    public interface IRequestTypeService
    {
        Task<IEnumerable<RequestTypeDto>> GetAllRequestTypes();
        Task<RequestTypeDto> GetRequestTypeById(long Id);
        Task<RequestTypeDto> CreateRequestType(RequestTypeDto requestTypeDto);
        Task<RequestTypeDto> UpdateRequestType(RequestTypeDto requestTypeDto);
        Task DeleteRequestType(long Id);
    }
}
