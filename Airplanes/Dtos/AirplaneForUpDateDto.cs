using System.ComponentModel.DataAnnotations;
namespace Airplanes.Dtos
{
    public class AirplaneForUpDateDto
    {
        [Required][StringLength(20, ErrorMessage = "Maximum 20 characters")] public string Pname { get; set; }
        [Required] public int Pseat { get; set; }
        public int? Pmax_speed { get; set; }
        public float? Pheavy_load { get; set; }
    }
}
