using System;
using System.Collections.Generic;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AaronLuck : ControllerBase
    {
        [HttpGet]
        public List<object> Get()
        {
            SqlBuilder sqlBuilder = new SqlBuilder();
            SqlBuilder.Template builder = new SqlBuilder().AddTemplate("SELECT * from user_table");
            var ormModule = new BaseDapper();
            List<object> rs = ormModule.SelectTable<object>(builder.RawSql, builder.Parameters);

            return rs;
        }
    }
}