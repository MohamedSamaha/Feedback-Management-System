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
    public class FloorNumberRepository : GenericRepository<FloorNumber>, IFloorNumberRepository
    {
        public FloorNumberRepository(ApplicationDbContext Context) : base(Context)
        {

        }
    
    }
}
