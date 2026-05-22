using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using EcoDrive_vol2.Models;

namespace EcoDrive_vol2.Helpers
{
    class DatabaseHelper
    {
        private static string connString = "Host=localhost;Port=1903;Database=ecodrive;Username=postgres;Password=rachelsyaf1903";

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connString);
        }
    }
}
