using Google.Protobuf;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace User_kezelés
{
    public partial class Form1 : Form
    {

        public static Connect conn = new Connect();
        public static void Getdata()
        {
            conn.Connection.Open();

            string sql = "SELECT `FirstName`, `LastName`, `Password` FROM `data`";        

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

            MySqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            do
            {
                var user = new
                {
                    FirstName = dr.GetString(1),
                    LastName = dr.GetString(2),
                    Password = dr.GetString(3),
                };


            } while (dr.Read());

            dr.Close();



            conn.Connection.Close();
        }
        public static void addNewfelhasznalo(string firstname, string lastname, int password)

        {
            try
            {
                conn.Connection.Open();

                string sql = $"INSERT INTO `data`(`FirstName`, `LastName`, `Password`) VALUES ('{firstname}','{lastname}','{password}')";

                MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

                cmd.ExecuteNonQuery();

                conn.Connection.Close();
            }
            catch (Exception exeption)
            {
                Console.WriteLine(exeption.Message);
                Console.ReadKey();
            }


        }

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nev = textBox1.Text;
            var jelszo = textBox2.Text;

            if ()
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }



    }

}
