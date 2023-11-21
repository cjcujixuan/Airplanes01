using Dapper;
using Airplanes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Airplanes.Utilities;

namespace Airplanes.Controllers
{        
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        private readonly string _connectString = DbContext.ConnectionString();
        [HttpGet]// search all
        public async Task<IEnumerable<Airport>> GetAirplanes()
        {
            string sqlQuery = "SELECT * FROM Airport";
            using (var connection = new SqlConnection(_connectString))
            {
                var Airplanes = await connection.QueryAsync<Airport>(sqlQuery);
                return Airplanes.ToList();
            }
        }

        [HttpGet("{id}")]//search only id
        public async Task<Airport> GetAirportById(Guid id)
        {
            string sqlQuery = "SELECT * FROM Airport WHERE Aid = @Id";
            using (var connection = new SqlConnection(_connectString))
            {
                var Airport = await connection.QueryFirstOrDefaultAsync<Airport>(sqlQuery, new { Id = id });
                if (Airport == null)
                {
                    return new Airport();
                }
                return Airport;
            }
        }

        [HttpPost]// post
        public async Task<IActionResult> AddAirport(Airport Airport)
        {
            string sqlQuery = "INSERT  INTO  Airport  (Aid,  Aname, Aterminal, Aapron, Aarea)  VALUES (@Aid, @Aname, @Aterminal, @Aapron, @Aarea)";
            using (var connection = new SqlConnection(_connectString))
            {
                await connection.ExecuteAsync(sqlQuery, Airport);
                return Ok();
            }
        }

        [HttpPut("{id}")] //put
        public async Task<IActionResult> UpdateAirport(Airport airport, Guid id)
        {
            string sqlQuery = "UPDATE Airport SET Aname = @Aname, Aterminal = @Aterminal, Aapron = @Aapron, Aarea = @Aarea, SELECT * FROM Airport  WHERE Aid = @Aid";
            airport.Aid = id;

            using (var connection = new SqlConnection(_connectString))
            {
                await connection.ExecuteAsync(sqlQuery, airport);
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirport(int id)
        {
            string sqlQuery = "DELETE FROM Airport WHERE Aid = @Id";
            using (var connection = new SqlConnection(_connectString))
            {
                await connection.ExecuteAsync(sqlQuery, new { Id = id });
                return Ok();
            }
        }

    }
}
