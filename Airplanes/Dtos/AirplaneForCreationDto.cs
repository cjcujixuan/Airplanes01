using System.ComponentModel.DataAnnotations;
namespace Airplanes.Dtos
{
    public class AirplaneForCreation
    {
        [Required]
        [StringLength(20, ErrorMessage = "Maximum 20 characters")]
        public string Pname { get; set; }
        [Required] public int Pseat { get; set; }
    }
}
