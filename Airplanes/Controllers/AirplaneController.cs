using Dapper;
using Airplanes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Airplanes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirplaneController : ControllerBase 
    {
        private readonly string _connectString = DBUtil.ConnectionString(); 
        [HttpGet]// search all
        public async Task<IEnumerable<Airplane>> GetAirplanes()
        {
            string sqlQuery = "SELECT * FROM Airplane"; 
            using (var connection = new SqlConnection(_connectString))
                { var Airplanes = await connection.QueryAsync<Airplane>(sqlQuery); 
                return Airplanes.ToList(); }
        } 
        [HttpGet("{id}")]//search only id
        public async Task<Airplane> GetAirplane(Guid id) 
        {
            string sqlQuery = "SELECT * FROM Airplane WHERE Pid = @Id";
            using (var connection = new SqlConnection(_connectString))
            {
                var Airplane = await connection.QueryFirstOrDefaultAsync<Airplane>(sqlQuery, new { Id = id });
                if (Airplane == null)
                {
                    return new Airplane();
                }
                return Airplane;
            }
        }
        [HttpPost]// post
        public async Task<IActionResult> AddAirplane(Airplane Airplane)
        {
            string sqlQuery = "INSERT  INTO  Airplane  (Pid,  Pname, Pseats, Pmaxspeed, Pheavyload)  VALUES (@Pid, @Pname, @Pseats, @Pmaxspeed, @Pheavyload)";
            using (var connection = new SqlConnection(_connectString)) 
            {
                await connection.ExecuteAsync(sqlQuery, Airplane);
                return Ok(); 
            }
        }
        [HttpPut("{id}")] //put
        public async Task<IActionResult> UpdateAirplane(Airplane airplane, Guid id)
        {
            string sqlQuery = "UPDATE Airplane SET Pname = @Pname, Pseats = @Pseats, Pmaxspeed = @Pmaxspeed, Pheavyload = @Pheavyload, SELECT * FROM Airplane  WHERE Pid = @Pid";
            airplane.Pid = id;

            using (var connection = new SqlConnection(_connectString))
            {
                await connection.ExecuteAsync(sqlQuery, airplane);
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalendar(int id)
        {
            string sqlQuery = "DELETE FROM Airplane WHERE Pid = @Id";
            using (var connection = new SqlConnection(_connectString))
            {
                await connection.ExecuteAsync(sqlQuery, new { Id = id});
                return Ok();
            }
        }
    }
}























