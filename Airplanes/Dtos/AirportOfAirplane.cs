using System.ComponentModel.DataAnnotations;

namespace Airports.Dtos
{
    public class AirportOfAirplane
    {
        [Required]
        public int Aid { get; set; }
        [Required]
        public string Aname { get; set; }
        public List<String> Airport { get; set; } = new List<String>();
    }
}