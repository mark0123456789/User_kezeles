using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace User_kezelés
{
    public partial class Form1 : Form
    {

        public static Connect conn = new Connect();
        public static void vegignezes()
        {
            conn.Connection.Open();

            string sql = "SELECT `ID`,`FirstName`,`LastName`,`Password` FROM `data`";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

            MySqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            do
            {

                int id = dr.GetInt32(0);
                string FirstName = dr.GetString(1);
                string LastName = dr.GetString(2);
                string Password = dr.GetString(3);




            } while (dr.Read());

            dr.Close();


            conn.Connection.Close();
        }

        public static void addNewfelhasznalo(string firstname, string lastname, int password)

        {
                conn.Connection.Open();

                string sql = $"INSERT INTO `data`(`FirstName`, `LastName`, `Password`) VALUES ('{firstname}','{lastname}','{password}')";

                MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

                cmd.ExecuteNonQuery();

                conn.Connection.Close();
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
