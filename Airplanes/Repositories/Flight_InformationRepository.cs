using Airplanes.Contracts;
using Airplanes.Models;
using Airplanes.Utilities;
using Dapper;
using Airplanes.Dtos;
using System.Data;

namespace Airplanes.Repositories
{
    public class Flight_InformationRepository : IFlight_Information
    {
    private readonly DbContext _dbContext; 

        public Flight_InformationRepository(DbContext dbContext)
        {
            // 注入DbContext 服務
            _dbContext = dbContext;
        }

        // 查詢所有Flight_information資料的實作
        public async Task<IEnumerable<Flight_information>> GetAllFlight_informations()
        {
            string sqlQuery = "SELECT * FROM Flight_information";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行查詢
                var Flight_informations = await connection.QueryAsync<Flight_information>(sqlQuery);
                return Flight_informations.ToList();
            }
        }
        // 查詢單一Flight_information資料（依指定Id）
        public async Task<Flight_information> GetFlight_informationById(Guid id)
        {
            string sqlQuery = "SELECT * FROM Flight_information WHERE Iid = @Id";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行查詢
                var Flight_information = await 
                connection.QueryFirstOrDefaultAsync<Flight_information>(sqlQuery, new { Id = id });
               return Flight_information;
            }
        }
        // 新增Flight_information資料
        public async Task<Flight_InformationForCreationDto> CreateFlight_information(Flight_InformationForCreationDto Flight_information)
        {
            string sqlQuery = "INSERT INTO Flight_information (Iname, Ideparture_airport) VALUES (@Iname, @Ideparture_airport)";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行新增
                await connection.ExecuteAsync(sqlQuery, Flight_information);
                return Flight_information;
            }
        }
        // 更新Flight_information資料（依指定id）
        public async Task UpdateFlight_information(Guid id, Flight_InformationForUpdateDto Flight_information)
        {
            string sqlQuery = "UPDATE Flight_information SET Iname = @Iname, Ideparture_airport = @Ideparture_airport, Iarrived_airport = @Iarrived_airport, Ideparture_time = @Ideparture_time, Iarrived_time = @Iarrived_time,Istatus = @Istatus WHERE Iid = @Id";
            // 建立參數物件
            var parameters= new DynamicParameters();
            // 加入參數
            parameters.Add("Id", id, DbType.Guid);
            parameters.Add("Iname", Flight_information.Iname, DbType.String);
            parameters.Add("Ideparture_airport", Flight_information.Ideparture_airport, DbType.String);
            parameters.Add("Iarrived_airport", Flight_information.Iarrived_airport, DbType.String);
            parameters.Add("Ideparture_time", Flight_information.Ideparture_time, DbType.DateTime);
            parameters.Add(" Iarrived_time", Flight_information.Iarrived_time, DbType.DateTime);
            parameters.Add(" Istatus", Flight_information.Istatus, DbType.Int64);
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行更新
                await connection.ExecuteAsync(sqlQuery, parameters);
            }
        }
        // 刪除Flight_information資料（依指定id）
        public async Task DeleteFlight_information(Guid id)
        {
            string sqlQuery = "DELETE FROM Flight_information WHERE Iid = @Id";
            // 建立參數物件
            var parameters= new DynamicParameters();
            // 加入參數
            parameters.Add("Id", id, DbType.Guid);
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行刪除
                await connection.ExecuteAsync(sqlQuery, parameters);
            }
        }
    }
}
