using FeedbackSystem.Core.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeedbackSystem.BussinessLogic.Logic;
using FeedbackSystem.Core.Entities;
using FeedbackSystem.Infrastructure.Data;

namespace FeedbackSystem.BusinessLogic.Logic.Repositories
{
    public class ClassificationRepository : GenericRepository<Classification>, IClassificationRepository
    {
        public ClassificationRepository(ApplicationDbContext Context) : base(Context)
        {

        }
    
    }
}
