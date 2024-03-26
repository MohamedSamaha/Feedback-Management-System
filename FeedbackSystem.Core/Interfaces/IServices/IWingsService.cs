using FeedbackSystem.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackSystem.Core.Interfaces.IServices
{
    public interface IWingsService
    {
        Task<IEnumerable<WingDto>> GetAllWings();
        Task<WingDto> GetWingById(long Id);
        Task<WingDto> CreateWing(WingDto wingDto);
        Task<WingDto> UpdateWing(WingDto wingDto);
        Task DeleteWing(long Id);
    }
}
