using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DeLyserrodSpejdere.Model
{
    internal static class DBConnector
    {
        private static SqlConnection _sqlConn;

        public static void ConnectToDB()
        {
            IConfigurationRoot config = new ConfigurationBuilder().AddUserSecrets(Assembly.GetExecutingAssembly(), optional: true).Build();
            string connectionsString = config["SaifsConnectionString"];
            _sqlConn = new SqlConnection(connectionsString);

            _sqlConn.Open();
        }

        public static void DisconnectToDb()
        {
            _sqlConn.Close();
        }

        public static SqlConnection SqlConnection
        {
            get { return _sqlConn; }
        }
    }
}