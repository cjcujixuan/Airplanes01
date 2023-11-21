using Airplanes.Dtos;
using Airplanes.Models;

namespace Airplanes.Contracts
{
    public interface IFlight_Information
    {
        // 查詢所有Flight_Information資料的介面
        public Task<IEnumerable<Flight_information>> GetAllFlight_informations();
        // 查詢單一Flight_information資料（依指定id）
        public Task<Flight_information> GetFlight_informationById(Guid id);
        // 新增Flight_Information資料
        public Task<Flight_InformationForCreationDto> CreateFlight_information(Flight_InformationForCreationDto Flight_information);
        // 更新Flight_Information資料（依指定id）
        public Task UpdateFlight_information(Guid id, Flight_InformationForUpdateDto Flight_information);
        // 刪除Flight_Information資料（依指定id）
        public Task DeleteFlight_information(Guid id);
    }
}
