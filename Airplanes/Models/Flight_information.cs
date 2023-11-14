namespace Airplanes.Models
{
    public class Flight_information
    {
        public Guid Iid { get; set; }
        public string Iname { get; set; }
        public string Ideparture_airport { get; set; }
        public string Iarrived_airport { get; set; }
        public DateTime Ideparture_time { get; set; }
        public DateTime Iarrived_time { get; set; }
        public int Istatus { get; set; }
    }
}
