using AutoMapper;
using FeedbackSystem.BusinessLogic.Extentions;
using FeedbackSystem.Core.Dtos;
using FeedbackSystem.Core.Entities;
using FeedbackSystem.Core.Interfaces;
using FeedbackSystem.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackSystem.BusinessLogic.Services
{
    public class PlaceTypeService : IPlaceTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<UserModel> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PlaceTypeService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<UserModel> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<PlaceTypeDto> CreatePlaceType(PlaceTypeDto placeTypeDto)
        {
            try
            {
                var actualplaceType = _mapper.Map<PlaceType>(placeTypeDto);
                if (actualplaceType != null)
                {
                    var user = await _userManager.GetCurrentUserAsync(_httpContextAccessor.HttpContext);
                    actualplaceType.UserId = user.Id;
                    actualplaceType.CreatedAt = DateTime.Now;
                    await _unitOfWork.PlaceTypies.CreateAsync(actualplaceType);
                    _unitOfWork.Save();
                }
                return placeTypeDto;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task DeletePlaceType(long Id)
        {
            try
            {
                var placeType = await _unitOfWork.PlaceTypies.GetByLongIdAsync(Id);
                if (placeType != null)
                {
                    await _unitOfWork.PlaceTypies.DeleteAsync(placeType);
                    _unitOfWork.Save();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<PlaceTypeDto>> GetAllPlaceType()
        {
            try
            {
                var allPlaceTypies = await _unitOfWork.PlaceTypies.GetAllAsync();
                var withoutSoftDeletedItems = allPlaceTypies.Where(x => x.DeletedAt == null);
                return _mapper.Map<IEnumerable<PlaceTypeDto>>(withoutSoftDeletedItems);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<PlaceTypeDto> GetPlaceTypeById(long Id)
        {
            try
            {
                var placeType = await _unitOfWork.PlaceTypies.GetByLongIdAsync(Id);
                return _mapper.Map<PlaceTypeDto>(placeType);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<PlaceTypeDto> UpdatePlaceType(PlaceTypeDto placeTypeDto)
        {
            try
            {
                if (placeTypeDto != null)
                {
                    var updatedPlaceType = _mapper.Map<PlaceType>(placeTypeDto);
                    if (updatedPlaceType != null)
                    {
                        await _unitOfWork.PlaceTypies.UpdateAsync(updatedPlaceType);
                        _unitOfWork.Save();
                    }
                }
                return placeTypeDto;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
