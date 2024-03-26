namespace FeedbackSystem.UI.ViewModels
{
    public class PlaceVM
    {
        public long Id { get; set; }
        public long building { get; set; }
        public long wing { get; set; }
        public long placeType { get; set; }
        public long floorNumber { get; set; }
        public string placeCode { get; set; }
        public string placeDescription { get; set; }
        public short activation { get; set; }
    }
}
