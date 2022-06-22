using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBSforumsforms
{
	internal class Forum
	{
        public static List<Forum> FetchAll()
		{
            using SqlConnection connection = new SqlConnection(@"Server=JEREMYS-PC\SQLEXPRESS;Database=MBSforum;Trusted_Connection=True;");
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
