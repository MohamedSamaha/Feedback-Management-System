using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FeedbackSystem.Core.Entities
{
	[Table("ticket_images")]
	/*[Index("TicketId", Name = "ticket_images_tickets_id_foreign")]*/
	public class TicketImages : BaseModel
	{
		public string ImageName { get; set; }
		public string ImageFilePath { get; set; }
		public long? TicketId { get; set; }
	}
}
