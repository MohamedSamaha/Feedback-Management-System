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
    public class FloorNumberService : IFloorNumberService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<UserModel> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public FloorNumberService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<UserModel> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<FloorNumberDto> CreateFloorNumber(FloorNumberDto floorNumberDto)
        {
            try
            {
                var actualFloorNumber = _mapper.Map<FloorNumber>(floorNumberDto);
                if (actualFloorNumber != null)
                {
                    var user = await _userManager.GetCurrentUserAsync(_httpContextAccessor.HttpContext);
                    actualFloorNumber.UserId = user.Id;
                    actualFloorNumber.CreatedAt = DateTime.Now;
                    await _unitOfWork.FloorNumbers.CreateAsync(actualFloorNumber);
                    _unitOfWork.Save();
                }
                return floorNumberDto;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task DeleteFloorNumberDto(long Id)
        {
            try
            {
                var floorNumber = await _unitOfWork.FloorNumbers.GetByLongIdAsync(Id);
                if (floorNumber != null)
                {
                    await _unitOfWork.FloorNumbers.DeleteAsync(floorNumber);
                    _unitOfWork.Save();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<FloorNumberDto>> GetAllFloorNumbers()
        {
            try
            {
                var allFloorNumbers = await _unitOfWork.FloorNumbers.GetAllAsync();
                var withoutSoftDeletedItems = allFloorNumbers.Where(x => x.DeletedAt == null);
                return _mapper.Map<IEnumerable<FloorNumberDto>>(withoutSoftDeletedItems);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<FloorNumberDto> GetFloorNumberById(long Id)
        {
            try
            {
                var floorNumber = await _unitOfWork.FloorNumbers.GetByLongIdAsync(Id);
                return _mapper.Map<FloorNumberDto>(floorNumber);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<FloorNumberDto> UpdateFloorNumber(FloorNumberDto floorNumberDto)
        {
            try
            {
                if (floorNumberDto != null)
                {
                    var updatedFloorNumber = _mapper.Map<FloorNumber>(floorNumberDto);
                    if (updatedFloorNumber != null)
                    {
                        await _unitOfWork.FloorNumbers.UpdateAsync(updatedFloorNumber);
                        _unitOfWork.Save();
                    }
                }
                return floorNumberDto;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
