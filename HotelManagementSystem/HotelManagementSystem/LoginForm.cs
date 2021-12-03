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

namespace HotelManagementSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            CONNECT conn = new CONNECT();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand();
            string query = "SELECT * FROM hotel_db_project.users WHERE username=@usn AND password=@pass;";

            command.CommandText = query;
            command.Connection = conn.getConnection();

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = textBoxUsername.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBoxPassword.Text;


            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                this.Hide();
                Main_Form main_form = new Main_Form();
                main_form.Show();

            }
            else
            {
                if(textBoxUsername.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Enter your username to login", "No Username Entered", MessageBoxButtons.OK,MessageBoxIcon.Error);

                }
                
                else if (textBoxPassword.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Enter your password to login", "No password Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                else
                {
                    MessageBox.Show("This Username or Password does not exist.", "Wrong Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }





        }

        private void label4_Click(object sender, EventArgs e)
        {
            NewAdminUser newAdminUser_Form = new NewAdminUser();
            newAdminUser_Form.Show();
        }
    }
}
