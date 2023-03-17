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
    public class clientesController : ControllerBase
    {
        private string _connection = @"Server=mysqlapirest.mysql.database.azure.com; Database=apicredit; Uid=Administrador; Pwd=891210Alejo";

        [HttpGet("getclients")]

        public IActionResult Get()
        {
            IEnumerable<Models.clientes> list = null;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "select * from clientes";
                list = db.Query<Models.clientes>(sql);
            }
            return Ok(list);

        }

        [HttpPost("saveclient")]

        public IActionResult Insert(Models.clientes model)
        {
            int result=0;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "insert into clientes(num_doc, name, phone, address)"+
                    " values(@num_doc, @name, @phone, @address)";
                result = db.Execute(sql, model);
            }
            return Ok(result);

        }

        [HttpPut("updateclient")]

        public IActionResult Update(Models.clientes model)
        {
            int result = 0;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "UPDATE clientes set num_doc=@num_doc, name=@name, phone=@phone, address=@address where id=@id";
                result = db.Execute(sql, model);
            }
            return Ok(result);

        }

        [HttpDelete("deleteclient")]

        public IActionResult Delete(Models.clientes model)
        {
            int result = 0;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "DELETE from clientes where id=@id";
                result = db.Execute(sql, model);
            }
            return Ok(result);

        }
    }
}