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
    public partial class Quizzes : Form
    {
        int ticks, a, score;
        string ans;
        public Quizzes()
        {           
            InitializeComponent();
            timer1.Interval = 1000;
            ticks = 30;
            a = 1;
            connection newcon = new connection();
            newcon.constring();
            hide();
        }

        private void Quizzes_Load(object sender, EventArgs e)
        {
            dgrd();
        }

        public void hide()
        {
            label2.Hide();
            label4.Hide();
            panel1.Hide();
            label1.Hide();
            dataGridView1.Hide();
            button1.Hide();
        }
        public void dgrd()
        {
            connection.con.Open();
            string Query = "select fullname as 'FULL NAME', date as 'Date and Time', score as 'SCORE' from scoresheet";
            MySqlDataAdapter da = new MySqlDataAdapter(Query, connection.con);
            DataSet ds = new DataSet();
            da.Fill(ds, "scoresheet");
            dataGridView1.DataSource = ds.Tables[0];
            connection.con.Close();
        }
        public void clear()
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The exam consists of 10 set of multiple question pages that has 4 options. The first 5 question has a time limit of 30 sec. with 1 point for each correct answer while the remaining 5 has 1 min with 5 points each correct answer");
            question();
            button2.Enabled = false;
            dataGridView1.Hide();
            label1.Show();
            label4.Hide();
            button1.Show();
            panel1.Show();
            button3.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            a++;
            answer();
            if (a <= 5)
            {
                question();
                ticks = 30;
            }

            else if (a >= 6 && a <= 10)
            {
                question();
                ticks = 60;
            }


            else
            {
                timer1.Stop();
                label1.Hide();
                dataGridView1.Show();
                string insertQuery = "insert into scoresheet (fullname,score) VALUES ('" + label2.Text + "','" + label4.Text + "')";
                connection.con.Open();
                MySqlCommand cmd1 = new MySqlCommand(insertQuery, connection.con);
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Quiz is over!\n" + label2.Text + " " + "Your score is: " + label4.Text + "/30", "Quiz", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connection.con.Close();              
                label2.Hide();
                label4.Hide();
                panel1.Hide();            
                button1.Hide();
                dgrd();
                button2.Enabled = false;
                button3.Show();
            }

            clear();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                ans = radioButton1.Text;
            }
            else
            {
                ans = "no answer";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                ans = radioButton2.Text;
            }
            else
            {
                ans = "no answer";
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                ans = radioButton3.Text;
            }
            else
            {
                ans = "no answer";
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                ans = radioButton4.Text;
            }
            else
            {
                ans = "no answer";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = ticks.ToString() + "sec";
            ticks--;
            if (ticks == 0)
            {
                timer1.Stop();
                a++;
                answer();
                if (a <= 5)
                {
                    timer1.Start();
                    question();
                    ticks = 30;
                }

                else if (a >= 6 && a <= 10)
                {
                    timer1.Start();
                    question();
                    ticks = 60;
                }

                else
                {
                    timer1.Stop();
                    button2.Enabled = false;
                    string insertQuery = "insert into scoresheet (fullname,score) VALUES ('" + label2.Text + "','" + label4.Text + "')";
                    connection.con.Open();
                    MySqlCommand cmd1 = new MySqlCommand(insertQuery, connection.con);
                    cmd1.ExecuteNonQuery();
                    connection.con.Close();
                    button1.Hide();
                    dgrd();
                    dataGridView1.Show();
                    MessageBox.Show("Quiz is over!" + label2.Text + ", " + "Your score is: " + label4.Text + "/30", "Quiz", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    panel1.Hide();
                    label1.Hide();
                    label4.Hide();
                    button3.Show();
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
        }

        public void answer()
        {
            MySqlCommand cmd = new MySqlCommand("select * from quiz where ans = '" + ans + "'", connection.con);
            connection.con.Open();
            MySqlDataReader myreader = cmd.ExecuteReader();
            if (myreader.Read())
            {
                score = score + int.Parse(myreader["pts"].ToString());
                label4.Text = score.ToString();
            }

            connection.con.Close();
        }
        public void question()
        {
            timer1.Start();
            MySqlCommand cmd = new MySqlCommand("select * from quiz where qno = '" + a + "'", connection.con);
            connection.con.Open();
            MySqlDataReader myreader = cmd.ExecuteReader();
            if (myreader.Read())
            {
                label3.Text = myreader["question"].ToString();
                radioButton1.Text = myreader["opt1"].ToString();
                radioButton2.Text = myreader["opt2"].ToString();
                radioButton3.Text = myreader["opt3"].ToString();
                radioButton4.Text = myreader["opt4"].ToString();
            }

            else
            {
                MessageBox.Show("Thank you for answering the quiz.!!!");
            }

            connection.con.Close();
        }

    }
}
