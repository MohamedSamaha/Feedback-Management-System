using AutoMapper;
using FeedbackSystem.BusinessLogic.Extentions;
using FeedbackSystem.Core.Dtos;
using FeedbackSystem.Core.Entities;
using FeedbackSystem.Core.Interfaces;
using FeedbackSystem.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace FeedbackSystem.BusinessLogic.Services
{
    public class WingService : IWingsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<UserModel> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public WingService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<UserModel> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<WingDto> CreateWing(WingDto wingDto)
        {
            try
            {
                var actualWing = _mapper.Map<Wing>(wingDto);
                if (actualWing != null)
                {
                    var user = await _userManager.GetCurrentUserAsync(_httpContextAccessor.HttpContext);
                    actualWing.UserId = user.Id;
                    actualWing.CreatedAt = DateTime.UtcNow;
                    await _unitOfWork.Wings.CreateAsync(actualWing);
                    _unitOfWork.Save();
                }
                return wingDto;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task DeleteWing(long Id)
        {
            try
            {
                var wing = await _unitOfWork.Wings.GetByLongIdAsync(Id);
                if (wing != null)
                {
                    await _unitOfWork.Wings.DeleteAsync(wing);
                    _unitOfWork.Save();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<WingDto>> GetAllWings()
        {
            try
            {
                var allWings = await _unitOfWork.Wings.GetAllAsync();
                var withoutSoftDeletedItems = allWings.Where(x => x.DeletedAt == null);
                return _mapper.Map<IEnumerable<WingDto>>(withoutSoftDeletedItems);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<WingDto> GetWingById(long Id)
        {
            try
            {
                var wing = await _unitOfWork.Wings.GetByLongIdAsync(Id);
                return _mapper.Map<WingDto>(wing);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<WingDto> UpdateWing(WingDto wingDto)
        {
            try
            {
                if (wingDto != null)
                {
                    var updatedWing = _mapper.Map<Wing>(wingDto);
                    if (updatedWing != null)
                    {
                        await _unitOfWork.Wings.UpdateAsync(updatedWing);
                        _unitOfWork.Save();
                    }
                }
                return wingDto;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
