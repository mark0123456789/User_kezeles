using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_kezelés
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        

        public static Connect conn = new Connect();
        public static void GetAllData()
        {
            conn.Connection.Open();

            string sql = "SELECT * FROM `felhasznalok`";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

            MySqlDataReader dr = cmd.ExecuteReader();

            dr.Read();
            do
            {
                var Player = new
                {
                    ID = dr.GetInt32(0),
                    FirstName = dr.GetString(1),
                    LastName = dr.GetString(2),
                    Password = dr.GetString(3),
                    CreatedTime = dr.GetDateTime(4),
                    UpdatedTime = dr.GetDateTime(5),
                };

             
            } while (dr.Read());

            dr.Close();



            conn.Connection.Close();
        }
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
