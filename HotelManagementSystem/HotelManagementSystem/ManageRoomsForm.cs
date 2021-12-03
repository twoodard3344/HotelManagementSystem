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
    public partial class ManageRoomsForm : Form
    {
        public ManageRoomsForm()
        {
            InitializeComponent();
        }

        Room room = new Room();

        private void ManageRoomsForm_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = room.roomTypeList();
            comboBox1.DisplayMember = "label";
            comboBox1.ValueMember = "category_id";

            dataGridView1.DataSource = room.GetRoomList();



        }

        private void Add_New_Room_Button_Click(object sender, EventArgs e)
        {
            int type = Convert.ToInt32(comboBox1.SelectedValue.ToString());
            string phone = textBox2.Text;
            string free = "";

            try
            {

                int number = Convert.ToInt32(textBox1.Text);
                if (radioButton1.Checked)
                {
                    free = "YES";
                }
                else if (radioButton2.Checked)
                {
                    free = "NO";
                }
                
                if (room.addRoom(number,type,phone,free))
                {
                    dataGridView1.DataSource = room.GetRoomList();
                    MessageBox.Show("Room Added Successfully", "Add Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Room NOT added", "Add Room", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch(Exception ex)

            {
                MessageBox.Show(ex.Message, "Room Number Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Clear_All_Fields_Button_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.SelectedIndex = 0;
            textBox2.Text = "";

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1.SelectedValue = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            string free = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            if (free.Equals("YES"))
            {
                radioButton1.Checked = true;
            }

            else if (free.Equals("NO"))
            {
                radioButton2.Checked = true;

            }
        }

        private void Edit_Rooms_Button_Click(object sender, EventArgs e)
        {
            int type = Convert.ToInt32(comboBox1.SelectedValue.ToString());
            String phone = textBox2.Text;
            String free = "";

            try
            {
                int number = Convert.ToInt32(textBox1.Text);
                if (radioButton1.Checked)
                {
                    free = "YES";
                }
                else if (radioButton2.Checked)
                {
                    free = "NO";
                }

                if (room.editRoom(number, type, phone, free))
                {
                    dataGridView1.DataSource = room.GetRoomList();
                    MessageBox.Show("Room Data Updated", "Edit Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Room Data NOT Updated", "Edit Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Room Number Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Remove_Room_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int number = Convert.ToInt32(textBox1.Text);

                if (room.removeRoom(number))
                {
                    dataGridView1.DataSource = room.GetRoomList();
                    MessageBox.Show("Room Data Deleted", "Remove Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Room Data NOT Deleted", "Remove Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Room Number Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
