using api_with_ado.net.DB;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace api_with_ado.net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        Database db = new Database();

        [HttpPost]
        public ActionResult Post(object value)
        {
            var serialize = JsonConvert.SerializeObject(value);
            JObject jobject = JObject.Parse(serialize);
            string query = @"insert into Student (FirstName,LastName,Age) values (@FirstName,@LastName,@Age);";
            var parameters = new IDataParameter[]
            {
                 new SqlParameter("@FirstName", jobject["FirstName"].ToString()),
                 new SqlParameter("@LastName", jobject["LastName"].ToString()),
                 new SqlParameter("@Age",jobject["Age"].ToString())
            };
            if (db.ExecuteData(query, parameters) > 0)
            {

                return Ok(new { Result = "Saved" });
            }
            else
            {
                return NotFound(new { Result = "something went wrong" });

            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            string query = "select * from Employee";
            DataTable dt = db.GetData(query);
            var result = new ObjectResult(dt);
            return result;
        }
    }
}