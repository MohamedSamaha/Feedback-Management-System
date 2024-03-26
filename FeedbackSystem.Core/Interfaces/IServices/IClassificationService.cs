using FeedbackSystem.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackSystem.Core.Interfaces.IServices
{
    public interface IClassificationService
    {
        Task<IEnumerable<ClassificationDto>> GetAllClassifications();
        Task<ClassificationDto> GetClassificationById(long Id);
        Task<ClassificationDto> CreateClassification(ClassificationDto classificationDto);
        Task<ClassificationDto> UpdateClassification(ClassificationDto classificationDto);
        Task DeleteClassification(long Id);
    }
}
