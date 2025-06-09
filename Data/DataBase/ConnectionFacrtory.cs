
using MySql.Data.MySqlClient;

namespace Data
{
    public class DbConnectionFactory
    {
        private string ConnectionString;

        public DbConnectionFactory(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public MySqlConnection GetOpenConnection()
        {
            var connection = new MySqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }
    }
}