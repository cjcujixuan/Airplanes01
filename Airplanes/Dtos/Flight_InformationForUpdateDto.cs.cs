using System.ComponentModel.DataAnnotations;
namespace Airplanes.Dtos
{
    public class Flight_InformationForUpdateDto
    {
        [Required][StringLength(20, ErrorMessage = "Maximum 20 characters")] public string Iname { get; set; }
        [Required] public string Ideparture_airport { get; set; }
        public string? Iarrived_airport { get; set; }
        public DateTime? Ideparture_time { get; set; }
        public DateTime? Iarrived_time { get; set; }
        public int? Istatus { get; set; }
    }
}
