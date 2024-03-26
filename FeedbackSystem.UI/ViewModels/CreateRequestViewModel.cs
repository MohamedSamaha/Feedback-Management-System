namespace FeedbackSystem.UI.ViewModels
{
	public class CreateRequestViewModel
	{
        public long place { get; set; }
        public short rate { get; set; }
        public long senderType { get; set; }
        public long requestType { get; set; }
        public string otherRequestType { get; set; }
        public long classification { get; set; }
        public string otherClassification { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public List<IFormFile?>? uploadImgs { get; set; }
    }
}
