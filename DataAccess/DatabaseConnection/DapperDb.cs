using Dapper;
using WebForms.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebForms.Services
{
    public class DapperDb
    {
        private readonly string connString;
        public DapperDb()
        {
            connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }
        public void Read()
        {
            using (IDbConnection db = new SqlConnection(connString))
            {
                int userId = 1;
                User user = db.QueryFirstOrDefault<User>("select * from dbo.Users where id=@id", new { userId });

                IEnumerable<User> users = db.Query<User>("select * from users where Id>@Id", new { iD = 1 });
            }
        }
        public int Insert()
        {
            using (IDbConnection db = new SqlConnection(connString))
            {
                User user = new User()
                {
                    Name = "USER",
                    AddressId = 1
                };
                string insertQql = "INSERT INTO Users (Name, AddressId) VALUES (@Name, @AddressId)";
                int rowsAffected = db.Execute(insertQql, user);
                return rowsAffected;
            }
        }

        public int Update(int id)
        {
            using (IDbConnection db = new SqlConnection(connString))
            {
                User userToUpdate = new User()
                {
                    Id = id,
                    Name = "UPDATED USER",
                    AddressId = 2
                };
                string updateSql = "UPDATE Users SET Name = @Name, AddressId = @AddressId WHERE Id = @Id";
                int rowsAffected = db.Execute(updateSql, userToUpdate);
                return rowsAffected;
            }
        }

        public int Delete(int userId)
        {
            using (IDbConnection db = new SqlConnection(connString))
            {
                string deleteSql = "DELETE FROM Users WHERE Id = @Id";
                int rowsAffected = db.Execute(deleteSql, userId);
                return rowsAffected;
            }
        }
    }
}