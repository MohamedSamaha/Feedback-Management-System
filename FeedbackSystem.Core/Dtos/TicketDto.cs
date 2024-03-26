using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeedbackSystem.Core.Entities;

namespace FeedbackSystem.Core.Dtos
{
    public class TicketDto
    {
        public long Id { get; set; }
        public short Rate { get; set; }
        public long ClassificationId { get; set; }
        public long RequestTypeId { get; set; }
        public long PlaceId { get; set; }
        public long? ResponseTypeId { get; set; }
        public long SenderTypeId { get; set; }
        public string? Description { get; set; }
        public string? ResponseNotes { get; set; }
        public string? OtherRequest { get; set; }
        public string? OtherClassification { get; set; }
        public string? SenderName { get; set; }
        public string? SenderEmail { get; set; }
        public string? SenderPhone { get; set; }
        public string? UserId { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
	}
}
