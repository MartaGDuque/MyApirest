using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Dapper;

namespace ApiCredit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class creditController : ControllerBase
    {
        private string _connection = @"Server=mysqlapirest.mysql.database.azure.com; Database=apicredit; Uid=Administrador; Pwd=891210Alejo";

        [HttpGet("getcredit")]

        public IActionResult Get()
        {
            IEnumerable<Models.getcredit> list = null;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "CALL SelectAllCredits ";
                list = db.Query<Models.getcredit>(sql);
            }
            return Ok(list);

        }

        [HttpPost("savecredit")]

        public IActionResult Insert(Models.credit model)
        {
            int result = 0;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "insert into creditos(id_client, date, articles, cost, final_cost)" +
                    " values(@id_client, @date, @articles, @cost, @final_cost)";
                result = db.Execute(sql, model);
            }
            return Ok(result);

        }

        [HttpPut("updatecredit")]

        public IActionResult Update(Models.credit model)
        {
            int result = 0;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "UPDATE creditos set id_client=@id_client, date=@date, articles=@articles, cost=@cost, final_cost=@final_cost where id=@id";
                result = db.Execute(sql, model);
            }
            return Ok(result);

        }

        [HttpDelete("deletecredit")]

        public IActionResult Delete(Models.credit model)
        {
            int result = 0;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "DELETE from creditos where id=@id";
                result = db.Execute(sql, model);
            }
            return Ok(result);

        }
    }
}