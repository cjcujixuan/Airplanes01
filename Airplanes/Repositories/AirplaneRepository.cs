using Airplanes.Contracts;
using Airplanes.Models;
using Airplanes.Utilities;
using Dapper;
using Airplanes.Dtos;
using System.Data;

namespace Airplanes.Repositories
{
    public class AirplaneRepository : IAirplane
    {
        private readonly DbContext _dbContext;
        public AirplaneRepository(DbContext dbContext)
        {
            // 注入DbContext 服務
            _dbContext = dbContext;
        }
        // 查詢所有Airplane資料的實作
        public async Task<IEnumerable<Airplane>> GetAllAirplanes()
        {
            string sqlQuery = "SELECT * FROM Airplane";
            // 建立資料庫連線
            using (var connection = _dbContext.CreateConnection())
            {
                // 執行查詢
                var airplanes = await connection.QueryAsync<Airplane>(sqlQuery);
                return airplanes.ToList();
            }


        }



        public async Task<Airplane> GetAirplaneById(Guid id)
        {
            string sqlQuery = "SELECT * FROM Airplane WHERE Pid = @Id";
            using (var connection = _dbContext.CreateConnection())
            {
                var airplane = await
                    connection.QueryFirstOrDefaultAsync<Airplane>(sqlQuery, new { Id = id }); return airplane;
            }
        }




        public async Task<AirplaneForCreationDto> CreateAirplane(AirplaneForCreationDto airplane)
        {
            string sqlQuery = "INSERT INTO Airplane (Pname, Pseats, Pmaxspeed, Pheavyload) VALUES (@name, @seats, @maxspeed, @heavyload)";
            using (var connection = _dbContext.CreateConnection())
            {
                await connection.ExecuteAsync(sqlQuery, airplane);
                return airplane;
            }
        }




        public async Task UpdateAirplane(Guid id, AirplaneForUpDateDto airplane)
        {
            string sqlQuery = "UPDATE Airplane SET Pname = @name, Pseats = @seats, Pmaxspeed = @maxspeed, Pheavyload = @heavyload WHERE Pid = @id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Guid);
            parameters.Add("name", airplane.Pname, DbType.String);
            parameters.Add("seats", airplane.Pseat, DbType.Int32);
            parameters.Add("maxspeed", airplane.Pmax_speed, DbType.Double);
            parameters.Add("heavyload", airplane.Pheavy_load, DbType.Double);
            using (var connection = _dbContext.CreateConnection())
            {
                await connection.ExecuteAsync(sqlQuery, parameters);
            }
            throw new NotImplementedException();
        }


        public async Task DeleteAirplane(Guid id)
        {
            string sqlQuery = "DELETE FROM Airplane WHERE Pid = @id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Guid);

            using (var connection = _dbContext.CreateConnection())
            {
                await connection.ExecuteAsync(sqlQuery, parameters);
            }
        }


    }
}
