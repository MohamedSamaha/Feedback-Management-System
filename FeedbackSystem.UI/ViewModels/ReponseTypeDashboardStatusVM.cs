namespace FeedbackSystem.UI.ViewModels
{
    public class ReponseTypeDashboardStatusVM
    {
        public long AllTicketsResponses { get; set; }
        public long AllTicketsOfTypeNewRequest { get; set; }
        public long AllTicketsOfTypeProccessingRequest { get; set; }
        public long AllTicketsOfTypeSolvedRequest { get; set; }
        public long AllTicketsOfTypeClosedRequest { get; set; }
        public long AllTicketsOfTypeEngineerDep { get; set; }
    }
}
