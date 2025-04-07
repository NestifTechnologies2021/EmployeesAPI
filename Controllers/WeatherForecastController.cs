using System.Configuration;
using EmployeeAPI;
using Microsoft.AspNetCore.Mvc;

namespace SampleRestfulAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        IConfiguration _configuration;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }


        [HttpGet("GetLoggerInformation")]
        public IEnumerable<WeatherForecast> GetLoggerInformation()
        {
            string path = _configuration.GetSection("LogSettings:LogPath").Value;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            FileInfo.WriteInLogFile("check this log...", path);
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("GetEmployees")]
        public ActionResult GetEmployees()
        {
            EmployeeDB dBContext = new EmployeeDB();
            var list = dBContext.GetEmployeesList();
            return Ok(list);

        }
        [HttpPost]
        [Route("Add Employees")]
        public ActionResult AddEmployee([FromBody] Employee emp)
        {
            EmployeeDB dBContext = new EmployeeDB();
            bool isSuccess = dBContext.AddEmployee(emp);
            if (isSuccess)
                return Ok("Data inserted");
            else
                return Ok("Data Insertion Failure");
        }
        //[HttpDelete]
        //[Route("Delete Employees")]
        //public ActionResult DeleteEmployee(int employeeId)
        //{
        //    EmployeeDB dBContext = new EmployeeDB();
        //    {
        //        dBContext.DeleteEmployee(employeeId);
        //        return Ok("Employee deleted successfully");

        //    }
        //}
    }
}
