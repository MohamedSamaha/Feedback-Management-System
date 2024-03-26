using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackSystem.Core.Dtos
{
    public class PlaceDto
    {
        public long? Id { get; set; }
        public long BuildingId { get; set; }
        public long PlaceTypeId { get; set; }
        public long FloorNumberId { get; set; }
        public long WingId { get; set; }
        public string Code { get; set; } = null!;
        public string Description { get; set; } = null!;
        public short Activation { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
