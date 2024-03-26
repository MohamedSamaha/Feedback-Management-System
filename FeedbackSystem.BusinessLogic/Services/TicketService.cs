using AutoMapper;
using FeedbackSystem.BusinessLogic.Extentions;
using FeedbackSystem.Core.Dtos;
using FeedbackSystem.Core.Entities;
using FeedbackSystem.Core.Interfaces;
using FeedbackSystem.Core.Interfaces.IServices;
using FeedbackSystem.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FeedbackSystem.BusinessLogic.Services
{
    public class TicketService : ITicketService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<UserModel> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TicketService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<UserModel> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }


        public async Task<TicketDto> CreateTicketType(TicketDto ticketDto, List<TicketImagesDto?> ticketImageDto)
        {
            try
            {

                var actuaclTicket = _mapper.Map<Ticket>(ticketDto);
                if (actuaclTicket != null)
                {
                    var user = await _userManager.GetCurrentUserAsync(_httpContextAccessor.HttpContext);
                    actuaclTicket.UserId = user.Id;
                    actuaclTicket.CreatedAt = DateTime.Now;
                    await _unitOfWork.Tickets.CreateAsync(actuaclTicket);
                    _unitOfWork.Save();
                    if (ticketImageDto.Count() > 0)
                    {
                        foreach (var img in ticketImageDto)
                        {
                            var image = new TicketImages();
                            image.TicketId = actuaclTicket.Id;
                            image.ImageFilePath = img.ImageFilePath;
                            image.ImageName = img.ImageName;
                            image.CreatedAt = DateTime.Now;
                            image.CreatedBy = user.Id;

                            await _unitOfWork.Images.CreateAsync(image);
                            _unitOfWork.Save();

                        }
                    }


                }
                return ticketDto;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task DeleteTicket(long Id)
        {
            try
            {
                var ticket = await _unitOfWork.Tickets.GetByLongIdAsync(Id);
                if (ticket != null)
                {
                    await _unitOfWork.Tickets.DeleteAsync(ticket);
                    _unitOfWork.Save();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<TicketVM>> GetAllTickets()
        {
            try
            {
                var allTickets = await _unitOfWork.Tickets.EntityWithEagerLoad(x => x.DeletedAt == null, new string[] { });
                var ticketsVMList = new List<TicketVM>();
                foreach (var feedback in allTickets)
                {
                    var location = await _unitOfWork.Places.GetByLongIdAsync(feedback.PlaceId);
                    var classification = await _unitOfWork.Classifications.GetByLongIdAsync(feedback.ClassificationId);
                    var requestType = await _unitOfWork.Requests.GetByLongIdAsync(feedback.RequestTypeId);
                    var responseType = await _unitOfWork.Responses.GetByLongIdAsync(feedback.ResponseTypeId ?? new long());
                    var allResponseTypes = await _unitOfWork.Responses.GetAllAsync();
                    var allTicketImages = await _unitOfWork.Images.EntityWithEagerLoad(img => img.TicketId == feedback.Id, new string[] { });

                    if (classification != null && requestType != null && responseType != null && location != null)
                    {
                        var senderType = await _unitOfWork.Senders.GetByLongIdAsync(feedback.SenderTypeId);
                        var ticketVm = new TicketVM()
                        {
                            Id = feedback.Id,
                            CreatedDate = feedback.CreatedAt,
                            Rate = feedback.Rate,
                            Location = location.Code,
                            classification = classification.NameEn,
                            requestType = requestType.NameEn,
                            senderType = senderType.NameEn,
                            responseType = responseType.NameEn,
                            responseTypeId = responseType.Id,
                            senderTypeId = feedback.SenderTypeId,
                            SenderEmail = feedback.SenderEmail,
                            SenderName = feedback.SenderName,
                            SenderPhone = feedback.SenderPhone,
                            ResponseNotes = feedback.ResponseNotes,
                            Description = feedback.Description,
                            responseTypeList = _mapper.Map<IEnumerable<ResponseTypeDto>>(allResponseTypes),
                            TicketImages = _mapper.Map<IEnumerable<TicketImagesDto>>(allTicketImages)
                        };
                        ticketsVMList.Add(ticketVm);
                    }
                }
                return ticketsVMList;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public async Task<TicketDto> GetTicketById(long Id)
        {
            try
            {
                var ticket = await _unitOfWork.Tickets.GetByLongIdAsync(Id);
                return _mapper.Map<TicketDto>(ticket);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<TicketDto> UpdateTicket(TicketDto ticketDto)
        {
            try
            {
                if (ticketDto != null)
                {
                    var ticket = await _unitOfWork.Tickets.GetByLongIdAsync(ticketDto.Id);
                    ticket.ResponseTypeId = ticketDto.ResponseTypeId;
                    ticket.ResponseNotes = ticketDto.ResponseNotes;
                    if (ticket != null)
                    {
                        await _unitOfWork.Tickets.UpdateAsync(ticket);
                        _unitOfWork.Save();
                    }
                }
                return ticketDto;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


    }
}
