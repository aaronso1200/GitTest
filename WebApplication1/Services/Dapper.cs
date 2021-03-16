using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using System.Linq;
using System.Runtime.CompilerServices;

namespace WebApplication1.Services
{
    public class BaseDapper
    {
        private string _connStr = "";

        private string GetSQLConnection()
        {
            if (this._connStr != "") return this._connStr;
            
            string host = "DESKTOP-40VK2HB";
            string instance = "SQLEXPRESS";
            string dbName = "TestDB";
            string user = "sa";
            string password = "password";

            this._connStr =
                $"Persist Security Info=False;Data Source={host}\\{instance};User Id={user};Password={password};Initial Catalog={dbName}";
            return this._connStr;
        }

        public List<T> SelectTable<T>(string strSql, object selectorParameters)
        {
            List<T> results = null;
            using (SqlConnection conn = new SqlConnection(this.GetSQLConnection()))
            {
                results = conn.Query<T>(strSql, selectorParameters).ToList();
            }

            return results;
        }

        public bool Update<T>(T obj) where T : class
        {
            using (SqlConnection conn = new SqlConnection(this.GetSQLConnection()))
            {
                conn.Open();
                return conn.Update(obj);
            }
        }

        public bool Update<T>(IEnumerable<T> obj) where T : class
        {
            using (SqlConnection conn = new SqlConnection(this.GetSQLConnection()))
            {
                conn.Open();
                return conn.Update(obj);
            }
        }

        public long Insert<T>(IEnumerable<T> obj) where T : class
        {
            using (SqlConnection conn = new SqlConnection(this.GetSQLConnection()))
            {
                conn.Open();
                return conn.Insert(obj);
            }
        }


        public long Insert<T>(T obj) where T : class
        {
            using (SqlConnection conn = new SqlConnection(this.GetSQLConnection()))
            {
                conn.Open();
                return conn.Insert(obj);
            }
        }
    }
}