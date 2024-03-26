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
    public class ResponseTypeService : IResponseTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<UserModel> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ResponseTypeService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<UserModel> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ResponseTypeDto> CreateResponseType(ResponseTypeDto responseTypeDto)
        {
            try
            {
                var actualResponseType = _mapper.Map<ResponseType>(responseTypeDto);
                if (actualResponseType != null)
                {
                    var user = await _userManager.GetCurrentUserAsync(_httpContextAccessor.HttpContext);
                    actualResponseType.UserId = user.Id;
                    actualResponseType.CreatedAt = DateTime.Now;
                    await _unitOfWork.Responses.CreateAsync(actualResponseType);
                    _unitOfWork.Save();
                }
                return responseTypeDto;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task DeleteResponseType(long Id)
        {
            try
            {
                var responseType = await _unitOfWork.Responses.GetByLongIdAsync(Id);
                if (responseType != null)
                {
                    await _unitOfWork.Responses.DeleteAsync(responseType);
                    _unitOfWork.Save();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ResponseTypeDto>> GetAllResponseType()
        {
            try
            {
                var allResponses = await _unitOfWork.Responses.GetAllAsync();
                var withoutSoftDeletedItems = allResponses.Where(x => x.DeletedAt == null);
                return _mapper.Map<IEnumerable<ResponseTypeDto>>(withoutSoftDeletedItems);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseTypeDto> GetResponseTypeById(long Id)
        {
            try
            {
                var response = await _unitOfWork.Responses.GetByLongIdAsync(Id);
                return _mapper.Map<ResponseTypeDto>(response);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseTypeDto> UpdateResponseType(ResponseTypeDto responseTypeDto)
        {
            try
            {
                if (responseTypeDto != null)
                {
                    var updatedResponse = _mapper.Map<ResponseType>(responseTypeDto);
                    if (updatedResponse != null)
                    {
                        await _unitOfWork.Responses.UpdateAsync(updatedResponse);
                        _unitOfWork.Save();
                    }
                }
                return responseTypeDto;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
