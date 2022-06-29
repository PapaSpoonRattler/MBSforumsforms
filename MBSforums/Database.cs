using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBSforums
{
    internal class Database
    {
        public static void ExecuteCommand(string procedureName, Action<SqlCommand> action)
        {
            using SqlConnection connection = new SqlConnection(Config.ConnectionString);
            connection.Open();
            using SqlCommand cmd = new SqlCommand(procedureName, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            action(cmd);
            cmd.ExecuteNonQuery();
        }

        public static T ExecuteScalar<T>(string procedureName, Action<SqlCommand> action)
        {
            using SqlConnection connection = new SqlConnection(Config.ConnectionString);
            connection.Open();
            using SqlCommand cmd = new SqlCommand(procedureName, connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            action(cmd);
            return (T)Convert.ChangeType(cmd.ExecuteScalar(), typeof(T));
        }
    }
}
