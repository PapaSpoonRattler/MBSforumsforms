﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBSforums
{
	public class User
	{
		public static User Fetch(string username)
		{
			SqlConnection connection = new SqlConnection(Config.ConnectionString);
			connection.Open();
			var sql = $"SELECT * FROM users WHERE Username = @Username";
			SqlCommand cmd = new SqlCommand(sql, connection);
			cmd.Parameters.AddWithValue("@Username", $"'{username}'");
			SqlDataReader reader = cmd.ExecuteReader();

			reader.Read();
			var user = new User(reader);

			return user;
		}

		public static User Fetch(int userID)
		{
			SqlConnection connection = new SqlConnection(Config.ConnectionString);
			connection.Open();
			var sql = $"SELECT * FROM users WHERE UserID = @UserID";
			SqlCommand cmd = new SqlCommand(sql, connection);
			cmd.Parameters.AddWithValue("@UserID", $"{userID}");
			SqlDataReader reader = cmd.ExecuteReader();

			reader.Read();
			var user = new User(reader);

			return user;
		}

		public static List<User> FetchAll()
		{
			SqlConnection connection = new SqlConnection(Config.ConnectionString);
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
