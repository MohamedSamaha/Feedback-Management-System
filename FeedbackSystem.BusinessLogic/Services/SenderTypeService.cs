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
    public class SenderTypeService : ISenderTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<UserModel> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SenderTypeService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<UserModel> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<SenderTypeDto> CreateSenderType(SenderTypeDto senderTypeDto)
        {
            try
            {
                var actualSender = _mapper.Map<SenderType>(senderTypeDto);
                if (actualSender != null)
                {
                    var user = await _userManager.GetCurrentUserAsync(_httpContextAccessor.HttpContext);
                    actualSender.UserId = user.Id;
                    actualSender.CreatedAt = DateTime.Now;
                    await _unitOfWork.Senders.CreateAsync(actualSender);
                    _unitOfWork.Save();
                }
                return senderTypeDto;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task DeleteSenderType(long Id)
        {
            try
            {
                var sender = await _unitOfWork.Senders.GetByLongIdAsync(Id);
                if (sender != null)
                {
                    await _unitOfWork.Senders.DeleteAsync(sender);
                    _unitOfWork.Save();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<SenderTypeDto>> GetAllSenderTypes()
        {
            try
            {
                var allsenders = await _unitOfWork.Senders.GetAllAsync();
                var withoutSoftDeletedItems = allsenders.Where(x => x.DeletedAt == null);
                return _mapper.Map<IEnumerable<SenderTypeDto>>(withoutSoftDeletedItems);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<SenderTypeDto> GetSenderTypeById(long Id)
        {
            try
            {
                var sender = await _unitOfWork.Senders.GetByLongIdAsync(Id);
                return _mapper.Map<SenderTypeDto>(sender);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<SenderTypeDto> UpdateSenderType(SenderTypeDto senderTypeDto)
        {
            try
            {
                if (senderTypeDto != null)
                {
                    var updatedSender = _mapper.Map<SenderType>(senderTypeDto);
                    if (updatedSender != null)
                    {
                        await _unitOfWork.Senders.UpdateAsync(updatedSender);
                        _unitOfWork.Save();
                    }
                }
                return senderTypeDto;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
