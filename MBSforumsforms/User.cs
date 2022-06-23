using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBSforumsforms
{
	internal class User
	{
        public static User Fetch(int userID)
		{
            SqlConnection connection = new SqlConnection(@"Server=JEREMYS-PC\SQLEXPRESS;Database=MBSforum;Trusted_Connection=True;");
            connection.Open();
            var sql = $"SELECT * FROM users WHERE UserID = {userID}";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            var user = new User(reader);

            return user;
        }

		public static List<User> FetchAll()
		{
            SqlConnection connection = new SqlConnection(@"Server=JEREMYS-PC\SQLEXPRESS;Database=MBSforum;Trusted_Connection=True;");
            connection.Open();
            var sql = "SELECT * FROM users";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            List<User> users = new List<User>();
            while (reader.Read())
            {
                var user = new User(reader);

                users.Add(user);
            }
            return users;
        }

        //public static User FetchAuthor(int postAuthorID)
        //{
        //    SqlConnection connection = new SqlConnection(@"Server=JEREMYS-PC\SQLEXPRESS;Database=MBSforum;Trusted_Connection=True;");
        //    connection.Open();
        //    var sql = "SELECT * FROM users INNER JOIN posts ON users.UserID = posts.PostAuthorID";
        //    SqlCommand cmd = new SqlCommand(sql, connection);
        //    SqlDataReader reader = cmd.ExecuteReader();

        //    User users = new User();
        //    while (reader.Read())
        //    {
        //        if (userID == postAuthorID)
        //        {
        //            txtPostAuthor = (string)reader["Username"];
        //        }
        //    }
        //    return;
        //}

        static public int CurrentUserID { get; set; }
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User(SqlDataReader reader)
		{
            UserID = (int)reader["UserID"];
            Username = (string)reader["Username"];
            Password = (string)reader["Password"];
		}
	}
}
