using Airplanes.Dtos;
using Airports.Dtos;
namespace Airplanes.Contracts
{
    public interface ICross
    {
        //P04第10頁 
        public Task<AirportOfAirplane> GetAirportByAirplaneId(Guid id);

        public Task<AirplaneOfAirport> GetAirplaneByAirportId(Guid id);
    }
}
