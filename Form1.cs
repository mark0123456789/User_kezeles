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

        private bool beleptet(string firstname, string lastname, string pass)
        {
            conn.Connection.Open();

            string sql = $"SELECT `ID` FROM `data` WHERE `FirstName`= '{firstname}' and `LastName`= '{lastname}' and `Password`= '{pass}'";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
           MySqlDataReader dr = cmd.ExecuteReader();

            bool van = dr.Read();

            conn.Connection.Close();

                return van;

        }
        private string regisztrál(string firstname, string lastname, string pass) 
        {

            conn.Connection.Open();

            string sql = $"INSERT INTO `data`( `FirstName`, `LastName`, `Password`, `CreatedTime`, `UpdatedTime`) VALUES ('{firstname}','{lastname}','{pass}','{DateTime.Now.ToString("yyyy-MM-dd")}','{DateTime.Now.ToString("yyyy-MM-dd")}')";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

                var result = cmd.ExecuteNonQuery();

            conn.Connection.Close();

           return result > 0 ? "sikeres regisztrálció" : "sikertelen regisztráció";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] darabol = textBox1.Text.Split(' ');
            if (beleptet(darabol[1], darabol[0], textBox2.Text) == true)
            {
                MessageBox.Show("regisztrált tag.");
            }
            else
            {
                MessageBox.Show("nem regisztrált tag.");
                showreg();
                string[] darabol2 = textBox1.Text.Split(' ');
                textBox5.Text = darabol2[1];
                textBox4.Text = darabol2[0];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3==textBox6)
            {
            regisztrál(textBox5.Text, textBox4.Text, textBox3.Text);
                hidereg();
            }
            else
            {
                MessageBox.Show("A két jelszó nem eggyezik meg");
            }
        
        }

        private void feltolt()
        {
            conn.Connection.Open();

            string sql = $"SELECT `ID`, `LastName`,`FirstName`, `CreatedTime`, `UpdatedTime` FROM `data`";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
            MySqlDataReader dr = cmd.ExecuteReader();

            bool van = dr.Read();

            while (dr.Read()) {
           
                listBox1.Items.Add($"{dr.GetInt32(0)},{dr.GetString(1)},{dr.GetString(2)},{dr.GetDateTime(3).ToString("yyyy-MM-dd")}");
            }
            conn.Connection.Close();
            
        }

        private void hidereg()
        {
            label3.Visible = label4.Visible = label5.Visible = label6.Visible = false;
            textBox3.Visible = textBox4.Visible = textBox5.Visible = textBox6.Visible = false;
            button2.Visible = false;
        }

        private void showreg()
        {
            label3.Visible = label4.Visible = label5.Visible = label6.Visible = true;
            textBox3.Visible = textBox4.Visible = textBox5.Visible = textBox6.Visible = true;
            button2.Visible = true;
        }

    }

}
