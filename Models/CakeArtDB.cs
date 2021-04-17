using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace CakeArtWebAPI.Models
{
    public class CakeArtDB
    {
        private static string connectionString = @"Data Source=DESKTOP-5M58GH9\SQLEXPRESS;Initial Catalog=CakeArt;Integrated Security=True";
        private static SqlConnection connection = new SqlConnection(connectionString);

        SqlDataReader reader;

        //Get Functions
        public List<Product> getAllCakes()
        {
            connection.Open();
            List<Product> Cakes = new List<Product>();
            Product p;
            string str = "SELECT * FROM Cakes";
            SqlCommand cmd = new SqlCommand(str, connection);
            reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                p = new Product((int)reader["id"], (string)reader["Name"],(string)reader["Price"]);
                Cakes.Add(p);
            }
            connection.Close();

            return Cakes;

        }

        public List<Product> getAllCookies()
        {
            connection.Open();
            List<Product> Cookies = new List<Product>();
            Product p;
            string str = "SELECT * FROM Cookies";
            SqlCommand cmd = new SqlCommand(str, connection);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                p = new Product((int)reader["id"], (string)reader["Name"], (string)reader["Price"]);
                Cookies.Add(p);
            }
            connection.Close();

            return Cookies;

        }

        public List<Product> getAllSpecial()
        {
            connection.Open();
            List<Product> Special = new List<Product>();
            Product p;
            string str = "SELECT * FROM Special";
            SqlCommand cmd = new SqlCommand(str, connection);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                p = new Product((int)reader["id"], (string)reader["Name"], (string)reader["Price"]);
                Special.Add(p);
            }
            connection.Close();

            return Special;

        }
        //End of Get Functions


        //Post Functions
        public int PostSpecial(Product Special)
        {
            string str = "INSERT INTO Special(Name,Price) " + "VALUES('" + Special.Name + "', " + Special.Price + ")";
            connection.Open();
            SqlCommand cmd = new SqlCommand(str, connection);
            int res = cmd.ExecuteNonQuery();
            connection.Close();
            return res;

        }

        public int PostCakes(Product NewCake)
        {
            string str = "INSERT INTO Cakes(Name,Price) " + "VALUES('" + NewCake.Name + "', " + NewCake.Price + ")";
            connection.Open();
            SqlCommand cmd = new SqlCommand(str, connection);
            int res = cmd.ExecuteNonQuery();
            connection.Close();
            return res;

        }


        
        public int PostCookies(Product NewCookie)
        {
            string str = "INSERT INTO Cookies(Name,Price) " + "VALUES('" + NewCookie.Name + "', " + NewCookie.Price + ")";
            connection.Open();
            SqlCommand cmd = new SqlCommand(str, connection);
            int res = cmd.ExecuteNonQuery();
            connection.Close();
            return res;
        }
        //End of Post Functions


        //Start of Put Functions
        public int PutCakes(int id, Product product)
        {
            int res = 0;
            
            List<Product> ProdList = getAllCakes();
            Product p = ProdList.SingleOrDefault(prod => prod.id == id);
            if (p != null)
            {
                connection.Open();
                string update = $"UPDATE Cakes Set Name='{product.Name}', Price='{product.Price}' WHERE id = {product.id}";
                SqlCommand cmd = new SqlCommand(update, connection);
                res = cmd.ExecuteNonQuery();
                connection.Close();
            }
            else
            {
                throw new Exception("Not Exist");
            }
            return res;
        }


        public int PutCookies(int id, Product product)
        {
            int res = 0;

            List<Product> ProdList = getAllCookies();
            Product p = ProdList.SingleOrDefault(prod => prod.id == id);
            if (p != null)
            {
                connection.Open();
                string update = $"UPDATE Cookies Set Name='{product.Name}', Price='{product.Price}' WHERE id = {product.id}";
                SqlCommand cmd = new SqlCommand(update, connection);
                res = cmd.ExecuteNonQuery();
                connection.Close();
            }
            else
            {
                throw new Exception("Not Exist");
            }
            return res;
        }

        public int PutSpecial(int id, Product product)
        {
            int res = 0;

            List<Product> ProdList = getAllSpecial();
            Product p = ProdList.SingleOrDefault(x => x.id == id);
            if (p != null)
            {
                connection.Open();
                string update = $"UPDATE Special Set Name='{product.Name}', Price='{product.Price}' WHERE id = {product.id}";
                SqlCommand cmd = new SqlCommand(update, connection);
                res = cmd.ExecuteNonQuery();
                connection.Close();
            }
            else
            {
                throw new Exception("Not Exist");
            }
            return res;
        }
        //End of Put Functions

        //Start Of Delete Functions
        public int DeleteCake(int id)
        {
            int res = 0;

            List<Product> ProdList = getAllCakes();
            Product p = ProdList.SingleOrDefault(x => x.id == id);
            if (p != null)
            {
                connection.Open();
                string update = $"DELETE FROM Cakes WHERE id = {p.id}";
                SqlCommand cmd = new SqlCommand(update, connection);
                res = cmd.ExecuteNonQuery();
                connection.Close();
            }
            else
            {
                throw new Exception("Not Exist");
            }
            return res;

        }


        public int DeleteCookies(int id)
        {
            int res = 0;

            List<Product> ProdList = getAllCookies();
            Product p = ProdList.SingleOrDefault(x => x.id == id);
            if (p != null)
            {
                connection.Open();
                string update = $"DELETE FROM Cookies WHERE id = {p.id}";
                SqlCommand cmd = new SqlCommand(update, connection);
                res = cmd.ExecuteNonQuery();
                connection.Close();
            }
            else
            {
                throw new Exception("Not Exist");
            }
            return res;

        }

        public int DeleteSpecial(int id)
        {
            int res = 0;

            List<Product> ProdList = getAllSpecial();
            Product p = ProdList.SingleOrDefault(x => x.id == id);
            if (p != null)
            {
                connection.Open();
                string update = $"DELETE FROM Special WHERE id = {p.id}";
                SqlCommand cmd = new SqlCommand(update, connection);
                res = cmd.ExecuteNonQuery();
                connection.Close();
            }
            else
            {
                throw new Exception("Not Exist");
            }
            return res;

        }



    }
}