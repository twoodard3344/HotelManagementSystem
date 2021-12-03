using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class ManageClientsForm : Form

    {
        Client client = new Client();


        public ManageClientsForm()
        {
            InitializeComponent();
        }

        private void buttonClear_Fields_Click(object sender, EventArgs e)
        {
            textBoxID.Text = "";
            textBoxfName.Text = "";
            textBoxLName.Text = "";
            textBoxPhoneNo.Text = "";
            textBoxState.Text = "";

        }

        private void buttonAddNewClients_Click(object sender, EventArgs e)
        {
            string fname = textBoxfName.Text;
            string lname = textBoxLName.Text;
            string phoneNo = textBoxPhoneNo.Text;
            string state = textBoxState.Text;

            Boolean InsertClient = client.InsertClient(fname, lname, phoneNo, state);

            if (fname.Trim().Equals("") || lname.Trim().Equals("") || phoneNo.Trim().Equals("") || state.Trim().Equals(""))
            {
                MessageBox.Show("Required Fields - First & Last Name + Phone Number", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else

            {
                if (InsertClient)
                {
                    
                    MessageBox.Show("New Client Inserted Successfully", "Client Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = client.GetClients();
                }
                else
                {
                    MessageBox.Show("ERROR - Client NOT inserted!", "Add Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }




        }

        private void ManageClientsForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = client.GetClients();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id;
            string fname = textBoxfName.Text;
            string lname = textBoxLName.Text;
            string phoneNo = textBoxPhoneNo.Text;
            string state = textBoxState.Text;

            try
            {


               id = Convert.ToInt32(textBoxID.Text);

                if (fname.Trim().Equals("") || lname.Trim().Equals("") || phoneNo.Trim().Equals(""))
                {
                    MessageBox.Show("Required Fields - First & Last Name + Phone Number", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else

                {


                    Boolean InsertClient = client.editClient(id,fname, lname, phoneNo, state);

                    if (InsertClient)
                    {
                        dataGridView1.DataSource = client.GetClients();
                        MessageBox.Show("Client Updated Successfully", "Edit Client", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("ERROR - Client NOT updated!", "Edit Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }



            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBoxfName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxLName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBoxPhoneNo.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBoxState.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxID.Text);

                if(client.DeleteClient(id))
                {
                    dataGridView1.DataSource = client.GetClients();
                    MessageBox.Show("Client Deleted Successfully", "Delete Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    MessageBox.Show("ERROR - Client NOT Deleted", "Delete Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                

            }


            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBoxfName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxLName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBoxPhoneNo.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBoxState.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }
    }
}
