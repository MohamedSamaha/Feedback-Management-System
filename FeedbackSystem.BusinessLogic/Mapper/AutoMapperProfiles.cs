using AutoMapper;
using FeedbackSystem.Core.Dtos;
using FeedbackSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackSystem.BusinessLogic.Mapper
{
	public class AutoMapperProfiles : Profile
	{
        public AutoMapperProfiles()
        {
			CreateMap<Building, BuildingDto>().ReverseMap();
			CreateMap<Classification, ClassificationDto>().ReverseMap();
			CreateMap<FloorNumber, FloorNumberDto>().ReverseMap();
			CreateMap<Place, PlaceDto>().ReverseMap();
			CreateMap<PlaceType, PlaceTypeDto>().ReverseMap();
			CreateMap<RequestType, RequestTypeDto>().ReverseMap();
			CreateMap<ResponseType, ResponseTypeDto>().ReverseMap();
			CreateMap<SenderType, SenderTypeDto>().ReverseMap();
			CreateMap<Ticket, TicketDto>().ReverseMap();
			CreateMap<UserDto, User>().ReverseMap();
			CreateMap<Wing, WingDto>().ReverseMap();
			CreateMap<TicketImages, TicketImagesDto>().ReverseMap();
			CreateMap<BaseModel, BaseDto>().ReverseMap();
			CreateMap<UserModel, UserModelDto>().ReverseMap();
		}
    }
}
