using Dapper;
using Airplanes.Contracts;
using Airplanes.Utilities;
using Airplanes.Dtos;
using Airports.Dtos;
namespace Airplanes.Repositories
{
    public class CrossRepository : ICross
    {
        private readonly DbContext _dbContext;
        public CrossRepository(DbContext dbContext)
        {  
            _dbContext = dbContext;
        }

        public async Task<AirplaneOfAirport> GetAirplaneByAirportId(Guid id)
        {
            string sqlQuery = "SELECT Aid, Aname,FROM Airport WHERE Aid = @Id;" +
            "SELECT P.Pname FROM Airplane A, Flight_Information I " +
           "WHERE I.Aid = @Id AND P.Pid = I.Pid;";
            using (var connection = _dbContext.CreateConnection())
            {
                var multi = await connection.QueryMultipleAsync(sqlQuery, new { Id = id });
                var airport = await multi.ReadSingleOrDefaultAsync<AirplaneOfAirport>();
                if (airport != null)
                    airport.Airplane = (await multi.ReadAsync<String>()).ToList();
                return airport;
            }
        }   

        public async Task<AirportOfAirplane> GetAirportByAirplaneId(Guid id)
        {
            string sqlQuery = "SELECT Pid, Pname FROM Airplane WHERE Pid = @Id;" +
            "SELECT A.Aname FROM Airport A, Flight_Information I " +
           "WHERE I.Pid = @Id AND A.Aid = I.Aid;";
            using (var connection = _dbContext.CreateConnection())
            {
                var multi = await connection.QueryMultipleAsync(sqlQuery, new { Id = id });
                var airplane = await multi.ReadSingleOrDefaultAsync<AirportOfAirplane>();
                if (airplane != null)
                    airplane.Airport = (await multi.ReadAsync<String>()).ToList();
                return airplane;
            }
        }

    }
}
