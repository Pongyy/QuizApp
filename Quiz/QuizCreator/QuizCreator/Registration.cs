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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
            connection newcon = new connection();
            newcon.constring();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (name.Text.Length == 0)
                {
                    MessageBox.Show("Fill up all required information");
                }
                else if (user.Text.Length == 0)
                {
                    MessageBox.Show("Fill up all required information");
                }
                else if (pass.Text.Length == 0)
                {
                    MessageBox.Show("Fill up all required information");
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to add this information?", "Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        MySqlCommand cmd1 = new MySqlCommand("insert into users (fullname,username,password)  VALUES ('" + name.Text + "','" + user.Text + "','" + pass.Text + "')");
                        cmd1.Connection = connection.con;
                        connection.con.Open();
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("Data Inserted");
                        name.Clear();
                        pass.Clear();
                        user.Clear();
                    }

                    else
                    {
                        MessageBox.Show("Adding of information was cancelled", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
                connection.con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
