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


namespace buggy
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }



        MySqlConnection con = new MySqlConnection("server=localhost;database = buggy;username =root;password = "); //setting up a profile to establish connection between c# and mysql
        
            
      
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string qry = "insert into register(USERNAME,PASSWORD,C_PASSWORD,EMAIL,TYPE) values " + "('" + textBox1.Text + "', '" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" +comboBox1.Text +"')";
            MySqlCommand cmd = new MySqlCommand(qry, con);

            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("inserted");
            }
            else
            {
                MessageBox.Show("not inserted");
            }
            con.Close();
        
        
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
