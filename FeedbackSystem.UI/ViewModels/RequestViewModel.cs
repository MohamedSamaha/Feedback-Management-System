using FeedbackSystem.Core.Dtos;

namespace FeedbackSystem.UI.ViewModels
{
	public class RequestViewModel
	{
		public IEnumerable<SenderTypeDto> senderTypes { get; set; }
		public IEnumerable<RequestTypeDto> requestTypes { get; set; }
		public IEnumerable<ClassificationDto> classifications { get; set; }
		public PlaceDto place { get; set; }
	}
}
