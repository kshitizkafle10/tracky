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

namespace buggy
{
    public partial class Form4 : Form
    {
        string id;
        public Form4(string username, string password, string rol, string id)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database = buggy;username =root;password = ");
            InitializeComponent();
           
            this.id = id;
            conn.Open();

            MySqlCommand cmd = new MySqlCommand("select USERNAME,EMAIL,TYPE from register where USERNAME='" + username + "' AND PASSWORD='" + password + "'", conn); //selecting column name from database 
            MySqlDataReader data = cmd.ExecuteReader();

            while (data.Read())
            {
                ListViewItem lvt = new ListViewItem(data["USERNAME"].ToString());
                lvt.SubItems.Add(data["EMAIL"].ToString());
                lvt.SubItems.Add(data["USERNAME"].ToString());

                lvt.SubItems.Add(data["TYPE"].ToString());
                listView1.Items.Add(lvt);//adding every rows data in the listview
            }
            conn.Close();//connection is closed
            bugList();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database = buggy;username =root;password = ");
            conn.Open();
            string qry = "insert into bug_list(project_name,line_num,class_name,issued_date,author,source_file,description,method_name) values " + "('" + textBox4.Text + "', '" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "')";

            MySqlCommand cmd = new MySqlCommand(qry, conn);
            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("inserted");
            }
            else
            {
                MessageBox.Show("not inserted");
            }
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        public void bugList()
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database = buggy;username =root;password = ");
            conn.Open();
            MySqlCommand cd = new MySqlCommand("select project_name,line_num,class_name,issued_date,author,source_file,description,method_name from bug_list", conn);

            MySqlDataReader dataa = cd.ExecuteReader();

            while (dataa.Read())
            {
                ListViewItem lvt = new ListViewItem(dataa["project_name"].ToString());
                lvt.SubItems.Add(dataa["project_name"].ToString());
                lvt.SubItems.Add(dataa["line_num"].ToString());

                lvt.SubItems.Add(dataa["class_name"].ToString());
                lvt.SubItems.Add(dataa["issued_date"].ToString());
                lvt.SubItems.Add(dataa["author"].ToString());
                lvt.SubItems.Add(dataa["source_file"].ToString());
                lvt.SubItems.Add(dataa["description"].ToString());
                lvt.SubItems.Add(dataa["method_name"].ToString());

                listView2.Items.Add(lvt);//adding every rows data in the listview
            }
            conn.Close();//connection is closed


        }
    }
}
