using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace ApiCredit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        private string _connection = @"Server=mysqlapirest.mysql.database.azure.com; Database=apicredit; Uid=Administrador; Pwd=891210Alejo";


        [HttpGet("getuser")]

        public IActionResult Get()
        {
            IEnumerable<Models.user> list = null;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "select * from usuarios";
                list = db.Query<Models.user>(sql);
            }
            return Ok(list);

        }
    }
}