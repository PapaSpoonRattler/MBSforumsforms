using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBSforums
{
    public class Post
    {
        public static Post Fetch(int postID)
        {
            SqlConnection connection = new SqlConnection(Config.ConnectionString);
            connection.Open();
            var sql = "SELECT * FROM posts WHERE ID = @PostID";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@PostID", postID);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
                return new Post(reader);
            else
                throw new Exception("Post Doesn't Exist");
        }

        public static List<Post> FetchAll()
        {
            using SqlConnection connection = new SqlConnection(Config.ConnectionString);
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
            SqlConnection connection = new SqlConnection(Config.ConnectionString);
            connection.Open();
            var sql = "DELETE FROM Posts WHERE ID = @PostID";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@PostID", postID);

            cmd.ExecuteNonQuery();
        }

        public static void PostEdit(string postDesc, int postID)
        {
            SqlConnection connection = new SqlConnection(Config.ConnectionString);
            connection.Open();
            var sql = $"UPDATE Posts SET PostDescrip = @PostDesc WHERE ID = @PostID ";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@PostID", postID);
            cmd.Parameters.AddWithValue("@PostDesc", postDesc);

            cmd.ExecuteNonQuery();
        }

        public static void Insert(int topicID, int numOfLikes, int postAuthorID, string postName, string postDesc, string postDate, string postTime)
        {
            Database.ExecuteCommand("InsertPost", cmd =>
            {
                cmd.Parameters.AddWithValue("@TopicID", topicID);
                cmd.Parameters.AddWithValue("@PostName", postName);
                cmd.Parameters.AddWithValue("@PostDesc", postDesc);
                cmd.Parameters.AddWithValue("@NumOfLikes", numOfLikes);
                cmd.Parameters.AddWithValue("@PostDate", postDate);
                cmd.Parameters.AddWithValue("@PostTime", postTime);
                cmd.Parameters.AddWithValue("@PostAuthorID", postAuthorID);

                cmd.ExecuteNonQuery();
            });

        }

        public static int FetchInsertID(int topicID, int numOfLikes, int postAuthorID, string postName, string postDesc, string postDate, string postTime)
        {
            return Database.ExecuteScalar<int>("InsertThenFetch", cmd =>
            {
                cmd.Parameters.AddWithValue("@TopicID", topicID);
                cmd.Parameters.AddWithValue("@PostName", postName);
                cmd.Parameters.AddWithValue("@PostDesc", postDesc);
                cmd.Parameters.AddWithValue("@NumOfLikes", numOfLikes);
                cmd.Parameters.AddWithValue("@PostDate", postDate);
                cmd.Parameters.AddWithValue("@PostTime", postTime);
                cmd.Parameters.AddWithValue("@PostAuthorID", postAuthorID);
            });
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
