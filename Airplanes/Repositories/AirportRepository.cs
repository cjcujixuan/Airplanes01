
using Airplanes.Contracts;
using Airplanes.Models;
using Airplanes.Utilities;
using Dapper;

namespace Airplanes.Repositories
{
    public class AirportRepository : IAirport
    {
        private readonly DbContext _dbContext; 
        public AirportRepository(DbContext dbContext)
        {
            // 注入DbContext 服務
            _dbContext = dbContext;
        }
        // 查詢所有Airport資料的實作
        public async Task<IEnumerable<Airport>> GetAllAirports()
        {
            string sqlQuery = "SELECT * FROM Airport";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行查詢
                var airports = await connection.QueryAsync<Airport>(sqlQuery);
                return airports.ToList();
            }
        }
        // 查詢單一Airport資料（依指定id）public async Task<Airport> GetAirportById(Guid id);
        // 新增Airport 資料public async Task<AirportForCreationDto> CreateAirport(AirportForCreationDto airport);
        //更新Airport 資料（依指定id）public async Task UpdateAirport(Guid id, AirportForUpdateDto airport);
        // 刪除Member 資料（依指定id）public async Task DeleteAirport(Guid id);

    }
}
