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
    public partial class NewAdminUser : Form
    {
        private string accessCode = "G4TGH90-7HNMP";
        NEWUSER newUser = new NEWUSER();

        public NewAdminUser()
        {
            InitializeComponent();
        }

        private void buttonAccessCode_Click(object sender, EventArgs e)
        {
            if (textBoxAccessCode.Text == accessCode)
            {
                label3.Show();
                label4.Show();
                textBox2.Show();
                textBox3.Show();
                button2.Show();
            }

            else
            {
                MessageBox.Show("Incorrect Access Code Entered. Please try again.", "Access Code", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string username = textBox2.Text;
            string password = textBox3.Text;

            Boolean InsertNewUser = newUser.InsertNewUser(username, password);

            if(username.Trim() == ""|| password.Trim()=="")
            {
                MessageBox.Show("Required Fields - New Admin Username + Password", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }

            else
            {
                if(InsertNewUser)
                {
                    MessageBox.Show("New Admin User Added Successfully", "New User Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    MessageBox.Show("ERROR: New Admin User Registration NOT Successful.Please Try Again.", "New User Add", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }


            

            

        }
    }
}
