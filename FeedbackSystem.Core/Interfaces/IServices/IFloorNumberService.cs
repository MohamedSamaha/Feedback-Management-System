using FeedbackSystem.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackSystem.Core.Interfaces.IServices
{
    public interface IFloorNumberService
    {
        Task<IEnumerable<FloorNumberDto>> GetAllFloorNumbers();
        Task<FloorNumberDto> GetFloorNumberById(long Id);
        Task<FloorNumberDto> CreateFloorNumber(FloorNumberDto floorNumberDto);
        Task<FloorNumberDto> UpdateFloorNumber(FloorNumberDto floorNumberDto);
        Task DeleteFloorNumberDto(long Id);
    }
}
