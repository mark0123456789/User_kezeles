using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace User_kezelés
{
    public partial class Form1 : Form
    {

        public static Connect conn = new Connect();


        public Form1()
        {
            InitializeComponent();
        }

        private bool beleptet(string firstname,string lastname,string pass)
        {
            conn.Connection.Open();

            string sql = $"SELECT `ID` FROM `felhasznalok` WHERE `FirstName`= '{firstname}' and `LastName`= '{lastname}' and `Password`= '{pass}'";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
           MySqlDataReader dr = cmd.ExecuteReader();

            bool van = dr.Read();

            conn.Connection.Close();

                return van;

         
        }
        private string regisztrál(string firstname, string lastname, string pass) 
        {

            conn.Connection.Open();

            string sql = $"INSERT INTO `felhasznalok`(`FirstName`, `LastName`, `Password`, `CreatedTime`, `UpdatedTime`) VALUES ('{firstname}','{lastname}','{pass}','{DateTime.Now.ToString("yyyy-MM-dd")}','{DateTime.Now.ToString("yyyy-MM-dd")}')";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

                var result = cmd.ExecuteNonQuery();

            conn.Connection.Close();

           return result > 0 ? "sikeres regisztrálció" : "sikertelen regisztráció";



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] darabol = textBox1.Text.Split(',');
            if (beleptet(darabol[1], darabol[0], textBox2.Text) == true)
            {
                MessageBox.Show("regisztrált tag.");
            }
            else
            {
                MessageBox.Show("nem regisztrált tag.");
               
            }
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
            regisztrál(textBox5.Text, textBox4.Text, textBox3.Text);
        }

    }

}
