using FeedbackSystem.Core.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackSystem.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        IBuildingRepository Buildings { get; set; }
        IClassificationRepository Classifications { get; set; }
        IFloorNumberRepository FloorNumbers { get; set; }
        IPlaceRepository Places { get; set; }
        IPlaceTypeRepository PlaceTypies { get; set; }
        IRequestTypeRepository Requests { get; set; }
        IResponseTypeRepository Responses { get; set; }
        ISenderTypeRepository Senders { get; set; }
        ITicketRepository Tickets { get; set; }
        IUserRepository Users { get; set; }
        IWingRepository Wings { get; set; }
        ITicketImageRepository Images { get; set; }
        IUserModelRepository UsersModel { get; set; }
        int Save();
    }
}
