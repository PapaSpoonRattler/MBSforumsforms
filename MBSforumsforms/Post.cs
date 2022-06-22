using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBSforumsforms
{
	internal class Post
	{
        public static List<Post> FetchAll()
		{
            using SqlConnection connection = new SqlConnection(@"Server=JEREMYS-PC\SQLEXPRESS;Database=MBSforum;Trusted_Connection=True;");
            connection.Open();
            var sql = "SELECT * FROM posts";
            using SqlCommand cmd = new SqlCommand(sql, connection);
            using SqlDataReader reader = cmd.ExecuteReader();

            List<Post> posts = new List<Post>();
            while (reader.Read())
            {
                var post = new Post(reader);

                posts.Add(post);
            }
            return posts;
        }

        public string PostDescrip { get; set; }
        public string PostName { get; set; }
        public string PostAuthorName { get; set; }
        public int PostAuthorID { get; set; }
        public int TopicID { get; set; }
        public int PostID { get; set; }
        public Post(SqlDataReader reader)
        {
            TopicID = (int)reader["TopicID"];
            PostID = (int)reader["ID"];
            PostDescrip = (string)reader["PostDescrip"];
            PostName = (string)reader["PostName"];
            PostAuthorID = (int)reader["PostAuthorID"];
        }
        public override string ToString()
        {
            return PostName;
        }
    }
}
