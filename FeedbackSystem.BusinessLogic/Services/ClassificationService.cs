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
    public class ClassificationService : IClassificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; private readonly UserManager<UserModel> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ClassificationService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<UserModel> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            this._mapper = mapper;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ClassificationDto> CreateClassification(ClassificationDto classificationDto)
        {
            try
            {
                var actualclassification = _mapper.Map<Classification>(classificationDto);
                if (actualclassification != null)
                {
                    var user = await _userManager.GetCurrentUserAsync(_httpContextAccessor.HttpContext);
                    actualclassification.UserId = user.Id;
                    actualclassification.CreatedAt = DateTime.UtcNow;
                    await _unitOfWork.Classifications.CreateAsync(actualclassification);
                    _unitOfWork.Save();
                }
                return classificationDto;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task DeleteClassification(long Id)
        {
            try
            {
                var classification = await _unitOfWork.Classifications.GetByLongIdAsync(Id);
                if (classification != null)
                {
                    await _unitOfWork.Classifications.DeleteAsync(classification);
                    _unitOfWork.Save();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ClassificationDto>> GetAllClassifications()
        {
            try
            {
                var allClassification = await _unitOfWork.Classifications.GetAllAsync();
                var withoutSoftDeletedItems = allClassification.Where(x => x.DeletedAt == null);
                return _mapper.Map<IEnumerable<ClassificationDto>>(withoutSoftDeletedItems);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ClassificationDto> GetClassificationById(long Id)
        {
            try
            {
                var classification = await _unitOfWork.Classifications.GetByLongIdAsync(Id);
                return _mapper.Map<ClassificationDto>(classification);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ClassificationDto> UpdateClassification(ClassificationDto classificationDto)
        {
            try
            {
                if (classificationDto != null)
                {
                    var updatedClassification = _mapper.Map<Classification>(classificationDto);
                    if (updatedClassification != null)
                    {
                        await _unitOfWork.Classifications.UpdateAsync(updatedClassification);
                        _unitOfWork.Save();
                    }
                }
                return classificationDto;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
