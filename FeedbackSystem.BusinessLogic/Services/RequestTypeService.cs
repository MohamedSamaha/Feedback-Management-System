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
    public class RequestTypeService : IRequestTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<UserModel> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RequestTypeService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<UserModel> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<RequestTypeDto> CreateRequestType(RequestTypeDto requestTypeDto)
        {
            try
            {
                var actualRequestType = _mapper.Map<RequestType>(requestTypeDto);
                if (actualRequestType != null)
                {
                    var user = await _userManager.GetCurrentUserAsync(_httpContextAccessor.HttpContext);
                    actualRequestType.UserId = user.Id;
                    actualRequestType.CreatedAt = DateTime.Now;
                    await _unitOfWork.Requests.CreateAsync(actualRequestType);
                    _unitOfWork.Save();
                }
                return requestTypeDto;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task DeleteRequestType(long Id)
        {

            {
                try
                {
                    var requestType = await _unitOfWork.Requests.GetByLongIdAsync(Id);
                    if (requestType != null)
                    {
                        await _unitOfWork.Requests.DeleteAsync(requestType);
                        _unitOfWork.Save();
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }

        public async Task<IEnumerable<RequestTypeDto>> GetAllRequestTypes()
        {
            try
            {
                var allRequestTypies = await _unitOfWork.Requests.GetAllAsync();
                var withoutSoftDeletedItems = allRequestTypies.Where(x => x.DeletedAt == null);
                return _mapper.Map<IEnumerable<RequestTypeDto>>(withoutSoftDeletedItems);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<RequestTypeDto> GetRequestTypeById(long Id)
        {
            try
            {
                var requestTypes = await _unitOfWork.Requests.GetByLongIdAsync(Id);
                return _mapper.Map<RequestTypeDto>(requestTypes);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<RequestTypeDto> UpdateRequestType(RequestTypeDto requestTypeDto)
        {
            try
            {
                if (requestTypeDto != null)
                {
                    var updatedRequestType = _mapper.Map<RequestType>(requestTypeDto);
                    if (updatedRequestType != null)
                    {
                        await _unitOfWork.Requests.UpdateAsync(updatedRequestType);
                        _unitOfWork.Save();
                    }
                }
                return requestTypeDto;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
