using System.ComponentModel.DataAnnotations;
namespace Airplanes.Dtos
{
    public class Flight_InformationForCreationDto
    {
        [Required]
        [StringLength(20, ErrorMessage = "Maximum 20 characters")]
        public string Iname { get; set; }
        [Required] public string Ideparture_airport { get; set; }
    }
}
