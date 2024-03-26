﻿using FeedbackSystem.BussinessLogic.Logic;
using FeedbackSystem.Core.Entities;
using FeedbackSystem.Core.Interfaces.IRepository;
using FeedbackSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackSystem.BusinessLogic.Logic.Repositories
{
    public class SenderTypeRepository : GenericRepository<SenderType>, ISenderTypeRepository
    {
        public SenderTypeRepository(ApplicationDbContext Context) : base(Context)
        {

        }
    }
}
