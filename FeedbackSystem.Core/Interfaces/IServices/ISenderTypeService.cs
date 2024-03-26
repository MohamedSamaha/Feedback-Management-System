using FeedbackSystem.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackSystem.Core.Interfaces.IServices
{
    public interface ISenderTypeService
    {
        Task<IEnumerable<SenderTypeDto>> GetAllSenderTypes();
        Task<SenderTypeDto> GetSenderTypeById(long Id);
        Task<SenderTypeDto> CreateSenderType(SenderTypeDto senderTypeDto);
        Task<SenderTypeDto> UpdateSenderType(SenderTypeDto senderTypeDto);
        Task DeleteSenderType(long Id);
    }
}
