using Dapper;
using ProjektProgramia.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjektProgramia.Services
{
    public class DapperDb
    {
        private readonly string connString;
        public DapperDb()
        {
            connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }
        public void Get()
        {
            using (IDbConnection db = new SqlConnection(connString))
            {
                var x = db.Query<User>("select * from dbo.Users");
            }
        }
        public IEnumerable<Product> ZiskatVsetkyProdukty()
        {
            using (IDbConnection db = new SqlConnection(connString))
            {
                return db.Query<Product>("SELECT Id, Nazov, Cena FROM Produkty");
            }
        }

        // Získanie jedného záznamu
        public Product ZiskatProduktPodlaId(int id)
        {
            using (IDbConnection db = new SqlConnection(connString))
            {
                return db.QuerySingleOrDefault<Product>("SELECT Id, Nazov, Cena FROM Produkty WHERE Id = @Id", new { Id = id });
            }
        }

        // Vloženie záznamu
        public int PridatProdukt(Product produkt)
        {
            using (IDbConnection db = new SqlConnection(connString))
            {
                string sql = "INSERT INTO Produkty (Nazov, Cena) VALUES (@Nazov, @Cena); SELECT CAST(SCOPE_IDENTITY() as int)";
                return db.Query<int>(sql, produkt).Single();
            }
        }

        // Aktualizácia záznamu
        public bool AktualizovatProdukt(Product produkt)
        {
            using (IDbConnection db = new SqlConnection(connString))
            {
                string sql = "UPDATE Produkty SET Nazov = @Nazov, Cena = @Cena WHERE Id = @Id";
                int rows = db.Execute(sql, produkt);
                return rows > 0;
            }
        }

        // Odstránenie záznamu
        public bool OdstranitProdukt(int id)
        {
            using (IDbConnection db = new SqlConnection(connString))
            {
                string sql = "DELETE FROM Produkty WHERE Id = @Id";
                int rows = db.Execute(sql, new { Id = id });
                return rows > 0;
            }
        }
    }
}