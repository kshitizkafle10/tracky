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
    public partial class Form1 : Form
    {
        private const string V = "TYPE";
        string rid;
        string rol;
        MySqlConnection conn = new MySqlConnection("server=localhost;database = buggy;username =root;password = "); //setting u
        public Form1()
        {
            InitializeComponent();
           
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 reg = new Form2();
            reg.Show();
            Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            MySqlCommand com = new MySqlCommand("select USERNAME,PASSWORD,TYPE,ID from register where USERNAME ='" +textBox1.Text + "' and PASSWORD='" + textBox2.Text + "'", conn);
            
            MySqlDataReader rd = com.ExecuteReader();
            while (rd.Read())
            {
                rol = rd["TYPE"].ToString();
                rid = rd["ID"].ToString();

            }
            if (rol.Equals("TESTER"))
            {
                Form4 d = new Form4(textBox1.Text, textBox2.Text, "TESTER",rid );
                d.Show();
                Visible = false;
            }
            else if (rol.Equals("DEVELOPER"))
            {
                Form4 d = new Form4(textBox1.Text, textBox2.Text, "DEVELOPER", rid);
                d.Show();
                Visible = false;
            }
            else
            {
                Form4 d = new Form4(textBox1.Text, textBox2.Text, "ADMIN", rid);
                d.Show();
                Visible = false;
            }
            conn.Close();

        }
    }
}
