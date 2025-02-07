using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg;
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
            ControlBox = false;
            radioButton1.Checked = true;
            hidereg();
            feltolt();
        }
        private static int userId = 0;
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

            listBox1.Items.Clear();
            feltolt();

            return result > 0 ? "sikeres regisztrálció" : "sikertelen regisztráció";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] darabol = textBox1.Text.Split(' ');
            if (beleptet(darabol[0], darabol[1], textBox2.Text) == true)
            {
                MessageBox.Show("regisztrált tag.");
            }
            else
            {
                MessageBox.Show("nem regisztrált tag.");
                showreg();
                string[] darabol2 = textBox1.Text.Split(' ');
                textBox5.Text = darabol2[0];
                textBox4.Text = darabol2[1];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true && textBox3 == textBox6) {
                MessageBox.Show( Frissit(userId, textBox5.Text, textBox4.Text, textBox3.Text));
                listBox1.Items.Clear();
                feltolt();
                hidereg();

            }

            else if(textBox3 == textBox6)
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

            while (dr.Read())
            {

                listBox1.Items.Add($"{dr.GetInt32(0)}.{dr.GetString(1)},{dr.GetString(2)},{dr.GetDateTime(3).ToString("yyyy-MM-dd")}");
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

        private string Frissit(int id, string firtname, string lastname, string password) 
        
        {
            conn.Connection.Open();
            string sql = $"UPDATE `data` SET `FirstName`='{firtname}',`LastName`='{lastname}',`Password`='{password}' WHERE `Id`= {id}";
            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
            var result = cmd.ExecuteNonQuery();
            conn.Connection.Close();
            return result > 0 ? "Sikeres frissítés" : "Sikertelen frissítés.";

        }

        private string torol()
        {
            conn.Connection.Open();
            string sql = $"DELETE FROM `data` WHERE `Id`= '{userId}'";
            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
            var result = cmd.ExecuteNonQuery();
            conn.Connection.Close();
            return result > 0 ? "Sikeres törlés" : "Sikertelen törlés.";
        }
        private void listbox1_doublecick(object sender, EventArgs e)

        {
            string[] getId = listBox1.SelectedItem.ToString().Split('.');
            userId = int.Parse(getId[0].TrimEnd());

            if (radioButton2.Checked == true)
            {
                MessageBox.Show(torol());
                listBox1.Items.Clear();
                feltolt();
            }
            else
            {
                showreg();
                string[] darabolNev = listBox1.SelectedItem.ToString().Split(' ');
                textBox4.Text = darabolNev[2];
                textBox3.Text = darabolNev[1];
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
