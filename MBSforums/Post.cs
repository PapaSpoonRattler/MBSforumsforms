using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBSforumsforms
{
	public class Post
	{
        public static Post Fetch(int postID)
		{
            SqlConnection connection = new SqlConnection(@"Server=JEREMYS-PC\SQLEXPRESS;Database=MBSforum;Trusted_Connection=True;");
            connection.Open();
            var sql = $"SELECT * FROM posts WHERE ID = {postID}";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            var post = new Post(reader);

            return post;
        }

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

        public static void Remove(int postID)
		{
            SqlConnection connection = new SqlConnection(@"Server=JEREMYS-PC\SQLEXPRESS;Database=MBSforum;Trusted_Connection=True;");
            connection.Open();
            var sql = $"DELETE FROM Posts WHERE ID = {postID}";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.ExecuteNonQuery();
        }

        public static void PostEdit(string postDesc, int postID)
		{
            SqlConnection connection = new SqlConnection(@"Server=JEREMYS-PC\SQLEXPRESS;Database=MBSforum;Trusted_Connection=True;");
            connection.Open();
            var sql = $"UPDATE Posts SET PostDescrip = '{postDesc}' WHERE ID = {postID} ";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.ExecuteNonQuery();
        }

        public static void Insert(int topicID, int numOfLikes, int postAuthorID, string postName, string postDesc, string postDate, string postTime)
		{
            using (SqlConnection connection = new SqlConnection(@"Server=JEREMYS-PC\SQLEXPRESS;Database=MBSforum;Trusted_Connection=True;"))
            {
                connection.Open();
                var sql = $"INSERT INTO posts VALUES ({topicID}, '{postName}', '{postDesc}', {numOfLikes}, '{postDate}', '{postTime}', {postAuthorID})";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                    cmd.ExecuteNonQuery();
            }
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
