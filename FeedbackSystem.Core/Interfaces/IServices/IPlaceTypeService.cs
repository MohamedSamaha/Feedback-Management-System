using FeedbackSystem.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackSystem.Core.Interfaces.IServices
{
    public interface IPlaceTypeService
    {
        Task<IEnumerable<PlaceTypeDto>> GetAllPlaceType();
        Task<PlaceTypeDto> GetPlaceTypeById(long Id);
        Task<PlaceTypeDto> CreatePlaceType(PlaceTypeDto placeTypeDto);
        Task<PlaceTypeDto> UpdatePlaceType(PlaceTypeDto placeTypeDto);
        Task DeletePlaceType(long Id);
    }
}
