using FeedbackSystem.Core.Interfaces;
using FeedbackSystem.Core.Interfaces.IRepository;
using FeedbackSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackSystem.BussinessLogic.Logic
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IBuildingRepository Buildings { get; set; }
        public IClassificationRepository Classifications { get; set; }
        public IFloorNumberRepository FloorNumbers { get; set; }
        public IPlaceRepository Places { get; set; }
        public IPlaceTypeRepository PlaceTypies { get; set; }
        public IRequestTypeRepository Requests { get; set; }
        public IResponseTypeRepository Responses { get; set; }
        public ISenderTypeRepository Senders { get; set; }
        public ITicketRepository Tickets { get; set; }
        public IUserRepository Users { get; set; }
        public IWingRepository Wings { get; set; }
		public ITicketImageRepository Images { get; set; }
        public IUserModelRepository UsersModel { get; set; }

        public UnitOfWork(
            ApplicationDbContext context,
            IBuildingRepository Buildings,
            IClassificationRepository Classifications,
            IFloorNumberRepository FloorNumbers,
            IPlaceRepository Places,
            IPlaceTypeRepository PlaceTypies,
            IRequestTypeRepository Requests,
            IResponseTypeRepository Responses,
            ISenderTypeRepository Senders,
            ITicketRepository Tickets,
            IUserRepository Users,
            IWingRepository Wings,
            ITicketImageRepository Images
,
            IUserModelRepository UsersModel)
        {
            _context = context;
            this.Buildings = Buildings;
            this.Classifications = Classifications;
            this.FloorNumbers = FloorNumbers;
            this.Places = Places;
            this.PlaceTypies = PlaceTypies;
            this.Requests = Requests;
            this.Responses = Responses;
            this.Senders = Senders;
            this.Tickets = Tickets;
            this.Users = Users;
            this.Wings = Wings;
            this.Images = Images;
            this.UsersModel = UsersModel;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

    }
}
