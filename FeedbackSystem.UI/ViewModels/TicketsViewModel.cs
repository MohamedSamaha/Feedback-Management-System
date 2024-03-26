using FeedbackSystem.Core.Dtos;
using FeedbackSystem.Core.Interfaces.IServices;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Reflection;

namespace FeedbackSystem.UI.ViewModels
{
    public class TicketsViewModel
    {
        public long Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public short? Rate { get; set; }
        public string? Location { get; set; }
        public string? requestType { get; set; }
        public string? responseType { get; set; }
        public string? senderType { get; set; }
        public string? classification { get; set; }
       

    }
}
