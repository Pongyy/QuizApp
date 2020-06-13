using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace QuizCreator
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            connection newcon = new connection();
            newcon.constring();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }        

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0)
            {
                MessageBox.Show("Fill up all information needed!","Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MySqlCommand cmd = new MySqlCommand("select * from users where username = '" + textBox1.Text + "' and password = '" + textBox2.Text + "'");
                cmd.Connection = connection.con;
                connection.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader myreader = cmd.ExecuteReader();
                if (myreader.Read())
                {
                    if (textBox1.Text == myreader["username"].ToString() && textBox2.Text == myreader["password"].ToString())
                    {
                        Quiz f3 = new Quiz();
                        f3.label2.Text = myreader["fullname"].ToString();
                        f3.label2.Hide();
                        f3.label4.Hide();
                        f3.panel1.Hide();
                        f3.label1.Hide();
                        f3.dataGridView1.Show();
                        f3.button1.Hide();
                        f3.Show();
                        this.Hide();
                    }

                    else
                    {
                        MessageBox.Show("No data found","ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            connection.con.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register reg = new Register();
            reg.Show();
        }
    }
}
