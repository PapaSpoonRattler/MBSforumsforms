﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBSforums
{
    public class Topic
	{
        public static Topic Fetch(int topicID)
		{
            SqlConnection connection = new SqlConnection(Config.ConnectionString);
            connection.Open();
            var sql = $"SELECT * FROM topics WHERE ID = @TopicID";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@TopicID", topicID);
            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            var topic = new Topic(reader);

            return topic;
        }

        public static List<Topic> FetchAll()
		{
            using SqlConnection connection = new SqlConnection(Config.ConnectionString);
            connection.Open();
            var sql = "SELECT * FROM topics";
            using SqlCommand cmd = new SqlCommand(sql, connection);
            using SqlDataReader reader = cmd.ExecuteReader();

            List<Topic> topics = new List<Topic>();
            while (reader.Read())
            {
                var topic = new Topic(reader);

                topics.Add(topic);
            }
            return topics;
        }

        public int ID { get; set; }
        public int ForumID { get; set; }
        public string TopicName { get; set; }
        public Topic(SqlDataReader reader)
        {
            ID = (int)reader["ID"];
            ForumID = (int)reader["ForumID"];
            TopicName = (string)reader["TopicName"];
        }
        public override string ToString()
        {
            return TopicName;
        }
    }
}
