using FeedbackSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackSystem.Core.Dtos
{
	public class TicketImagesDto : BaseDto
	{
		public string ImageName { get; set; }
		public string ImageFilePath { get; set; }
		public long? TicketId { get; set; }
	}
}
