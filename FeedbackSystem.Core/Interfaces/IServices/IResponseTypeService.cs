using FeedbackSystem.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackSystem.Core.Interfaces.IServices
{
    public interface IResponseTypeService
    {
        Task<IEnumerable<ResponseTypeDto>> GetAllResponseType();
        Task<ResponseTypeDto> GetResponseTypeById(long Id);
        Task<ResponseTypeDto> CreateResponseType(ResponseTypeDto responseTypeDto);
        Task<ResponseTypeDto> UpdateResponseType(ResponseTypeDto responseTypeDto);
        Task DeleteResponseType(long Id);
    }
}
