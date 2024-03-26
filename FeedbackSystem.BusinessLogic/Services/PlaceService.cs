using AutoMapper;
using FeedbackSystem.BusinessLogic.Extentions;
using FeedbackSystem.Core.Dtos;
using FeedbackSystem.Core.Entities;
using FeedbackSystem.Core.Interfaces;
using FeedbackSystem.Core.Interfaces.IServices;
using FeedbackSystem.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace FeedbackSystem.BusinessLogic.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<UserModel> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PlaceService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<UserModel> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<PlaceDto> CreatePlace(PlaceDto placeDto)
        {
            try
            {
                var actuaclPlace = _mapper.Map<Place>(placeDto);
                if (actuaclPlace != null)
                {
                    var user = await _userManager.GetCurrentUserAsync(_httpContextAccessor.HttpContext);
                    actuaclPlace.UserId = user.Id;
                    actuaclPlace.CreatedAt = DateTime.Now;
                    await _unitOfWork.Places.CreateAsync(actuaclPlace);
                    _unitOfWork.Save();
                }
                return placeDto;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task DeletePlace(long Id)
        {
            try
            {
                var place = await _unitOfWork.Places.GetByLongIdAsync(Id);
                if (place != null)
                {
                    await _unitOfWork.Places.DeleteAsync(place);
                    _unitOfWork.Save();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<PlaceViewModel>> GetAllPlaces()
        {
            try
            {
                var allPlaces = await _unitOfWork.Places.EntityWithEagerLoad(x => x.DeletedAt == null, new string[] { });
                var placeVMList = new List<PlaceViewModel>();
                foreach (var place in allPlaces)
                {
                    var building = await _unitOfWork.Buildings.GetByLongIdAsync(place.BuildingId);
                    var wing = await _unitOfWork.Wings.GetByLongIdAsync(place.WingId);
                    var placeType = await _unitOfWork.PlaceTypies.GetByLongIdAsync(place.PlaceTypeId);
                    var floor = await _unitOfWork.FloorNumbers.GetByLongIdAsync(place.FloorNumberId);

                    var placeVM = new PlaceViewModel()
                    {
                        Id = place.Id,
                        BuildingId = building.Id,
                        WingId = wing.Id,
                        PlaceTypeId = placeType.Id,
                        FloorId = floor.Id,
                        Building = building.NameEn,
                        PlaceCode = place.Code,
                        PlaceDescription = place.Description,
                        Active = place.Activation,
                        LastUpdated = place.UpdatedAt,
                        BuildingDto = _mapper.Map<IEnumerable<BuildingDto>>(await _unitOfWork.Buildings.EntityWithEagerLoad(x => true, new string[] { })),
                        WingDto = _mapper.Map<IEnumerable<WingDto>>(await _unitOfWork.Wings.EntityWithEagerLoad(x => true, new string[] { })),
                        PlaceTypeDto = _mapper.Map<IEnumerable<PlaceTypeDto>>(await _unitOfWork.PlaceTypies.EntityWithEagerLoad(x => true, new string[] { })),
                        FloorNumberDto = _mapper.Map<IEnumerable<FloorNumberDto>>(await _unitOfWork.FloorNumbers.EntityWithEagerLoad(x => true, new string[] { })),
                    };
                    placeVMList.Add(placeVM);
                }
                return placeVMList;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<PlaceDto> GetPlaceById(long Id)
        {
            try
            {
                var place = await _unitOfWork.Places.GetByLongIdAsync(Id);
                return _mapper.Map<PlaceDto>(place);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<PlaceDto> UpdatePlace(PlaceDto placeDto)
        {
            try
            {
                if (placeDto != null)
                {
                    var updatePlace = _mapper.Map<Place>(placeDto);
                    if (updatePlace != null)
                    {
                        await _unitOfWork.Places.UpdateAsync(updatePlace);
                        _unitOfWork.Save();
                    }
                }
                return placeDto;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
