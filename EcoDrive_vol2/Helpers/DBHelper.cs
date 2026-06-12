using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using EcoDrive_vol2.Models;

namespace EcoDrive_vol2.Helpers
{
    class DatabaseHelper
    {
        private static string connString = "Host=localhost;Port=5432;Database=Ecodrive_final;Username=postgres;Password=sabila.19";
        //private static string connString = "Host=localhost;Port=1903;Database=ecodrive;Username=postgres;Password=rachel123";
        //private static string connString = "Host=localhost;Port=5432;Database=ecodrive;Username=postgres;Password=langgeng847";

        // ntar punya kalian juga komen gini ya, biar enak kalau mau ganti password atau database, tinggal ganti di satu tempat aja

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connString);
        }
    }
}
