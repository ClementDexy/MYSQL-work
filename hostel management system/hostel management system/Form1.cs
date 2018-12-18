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

namespace hostel_management_system
{
    public partial class Form1 : Form
    {
        private string connectionString;
        private MySqlConnection connection;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            connectionString = "server=localhost;Database=hosteldb;Uid=root;Pwd=216218276Dd";
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var usernameText = textBox1.Text;
            var PasswordText = textBox2.Text;

            var selectCommand = new MySqlCommand();
            selectCommand.CommandText = "select * from users where username=@username AND password=@password";
            selectCommand.Parameters.AddWithValue("@username", usernameText);
            selectCommand.Parameters.AddWithValue("@password", PasswordText);

            selectCommand.Connection = connection;
            MySqlDataReader dataReader = selectCommand.ExecuteReader();
            if (dataReader.Read())
            {
                MessageBox.Show("Login Succes");
            }
            else
            {
                MessageBox.Show("Invalid username or Password");
            }
        }
        private void Test_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


    }
}
