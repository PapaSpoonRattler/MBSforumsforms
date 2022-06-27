using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBSforums
{
    public class Forum
	{
        public static Forum Fetch(int forumID)
		{
            SqlConnection connection = new SqlConnection(Config.ConnectionString);
            connection.Open();
            var sql = $"SELECT * FROM forums WHERE ID = {forumID}";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            var forum = new Forum(reader);

            return forum;
        }

        public static List<Forum> FetchAll()
		{
            using SqlConnection connection = new SqlConnection(Config.ConnectionString);
            connection.Open();
            var sql = "SELECT * FROM forums";
            using SqlCommand cmd = new SqlCommand(sql, connection);
            using SqlDataReader reader = cmd.ExecuteReader();

            List<Forum> forums = new List<Forum>();
            while (reader.Read())
            {
                var forum = new Forum(reader);
                forums.Add(forum);
            }
            return forums;
        }

        public int ID { get; set; }
        public string ForumName { get; set; }
        public Forum(SqlDataReader reader)
        {
            ID = (int)reader["ID"];
            ForumName = (string)reader["ForumName"];
        }
        public override string ToString()
        {
            return ForumName;
        }
    }
}
