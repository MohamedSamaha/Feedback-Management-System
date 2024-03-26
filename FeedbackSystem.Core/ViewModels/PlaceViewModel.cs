using FeedbackSystem.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackSystem.Core.ViewModels
{
    public class PlaceViewModel
    {
        public long Id { get; set; }
        public string Building { get; set; }
        public long BuildingId { get; set; }
        public long WingId { get; set; }
        public long PlaceTypeId { get; set; }
        public long FloorId { get; set; }
        public string PlaceCode { get; set; }
        public string PlaceDescription { get; set; }
        public short Active { get; set; }
        public DateTime? LastUpdated { get; set; }
        public IEnumerable<BuildingDto?>? BuildingDto { get; set; }
        public IEnumerable<WingDto?>? WingDto { get; set; }
        public IEnumerable<PlaceTypeDto?>? PlaceTypeDto { get; set; }
        public IEnumerable<FloorNumberDto?>? FloorNumberDto { get; set; }
    }
}
