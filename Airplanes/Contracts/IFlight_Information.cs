using Airplanes.Dtos;
using Airplanes.Models;

namespace Airplanes.Contracts
{
    public interface IFlight_Information
    {
        // 查詢所有Flight_Information資料的介面
        public Task<IEnumerable<Flight_InformationForCreationDto>> GetAllFlightInformation();
        // 查詢單一Airport資料（依指定id）
        public Task<Flight_InformationForCreationDto> GetFlightInformationById(Guid id);
        // 新增Flight_Information資料
        public Task<Flight_InformationForCreationDto> CreateFlightInformation(Flight_InformationForCreationDto FlightInformation);
        // 更新Flight_Information資料（依指定id）
        public Task UpdateFlightInformation(Guid id, Flight_InformationForCreationDto FlightInformation);
        // 刪除Flight_Information資料（依指定id）
        public Task DeleteFlightInformation(Guid id);
    }
}
