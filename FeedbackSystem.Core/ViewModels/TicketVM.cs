using FeedbackSystem.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackSystem.Core.ViewModels
{
    public class TicketVM
    {
        public long Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public short? Rate { get; set; }
        public string? Location { get; set; }
        public string? requestType { get; set; }
        public long? responseTypeId { get; set; }
        public string? responseType { get; set; }
        public string? senderType { get; set; }
        public long? senderTypeId { get; set; }
        public string? classification { get; set; }
        public string? SenderName { get; set; }
        public string? SenderEmail { get; set; }
        public string? SenderPhone { get; set; }
        public string? Description { get; set; }
        public string? ResponseNotes { get; set; }
        public IEnumerable<ResponseTypeDto?>? responseTypeList { get; set; }
        public IEnumerable<TicketImagesDto?>? TicketImages { get; set; }
    }
}
