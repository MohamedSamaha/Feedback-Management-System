using FeedbackSystem.Core.Dtos;
using FeedbackSystem.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackSystem.Core.Interfaces.IServices
{
    public interface IPlaceService
    {
        Task<IEnumerable<PlaceViewModel>> GetAllPlaces();
        Task<PlaceDto> GetPlaceById(long Id);
        Task<PlaceDto> CreatePlace(PlaceDto placeDto);
        Task<PlaceDto> UpdatePlace(PlaceDto placeDto);
        Task DeletePlace(long Id);
    }
}
