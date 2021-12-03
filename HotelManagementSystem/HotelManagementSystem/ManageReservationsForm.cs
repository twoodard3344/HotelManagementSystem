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
    public partial class ManageReservationsForm : Form
    {
        RESERVATION reservation = new RESERVATION();
        Room room = new Room();

        public ManageReservationsForm()
        {
            InitializeComponent();
        }

        private void ManageReservationsForm_Load(object sender, EventArgs e)
        {
            comboBox1_RoomType.DataSource = room.roomTypeList();
            comboBox1_RoomType.DisplayMember = "label";
            comboBox1_RoomType.ValueMember = "category_id";

            dataGridView1.DataSource = reservation.getAllReserv();

           


        }

        private void buttonAddNewClients_Click(object sender, EventArgs e)
        {
            try
            {
                int clientID = Convert.ToInt32(textBox_ClientID.Text);
                int roomNumber = Convert.ToInt32(comboBox1.SelectedValue);
                DateTime dateIn = dateTimePicker_Date_IN.Value;
                DateTime dateOut = dateTimePicker_DateOUT.Value;

                if (DateTime.Compare(dateIn.Date,DateTime.Now.Date)<0)
                {
                    MessageBox.Show("The Date In Must Be = or greater To Today's Date", "Invalid Date In", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (DateTime.Compare(dateOut.Date,dateIn.Date) < 0)
                {
                    MessageBox.Show("The Date Out Must Be = or greater To Date In", "Invalid Date Out", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    if(reservation.addReservation(roomNumber,clientID,dateIn,dateOut))
                    {
                        room.setRoomToNo(roomNumber);
                        dataGridView1.DataSource = reservation.getAllReserv();
                        MessageBox.Show("New Reservation Added", "Add Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Reservation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClear_Fields_Click(object sender, EventArgs e)
        {
            textBox_ClientID.Text = "";
            
            comboBox1_RoomType.SelectedValue = 0;
            dateTimePicker_Date_IN.Value = DateTime.Now;
            dateTimePicker_DateOUT.Value = DateTime.Now;
              
        }

        private void comboBox1_RoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                int type = Convert.ToInt32(comboBox1_RoomType.SelectedValue.ToString());
                comboBox1.DataSource = room.roomByType(type);
                comboBox1.DisplayMember = "number";
                comboBox1.ValueMember = "number";
            }
            catch(Exception)
            {

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int clientID = Convert.ToInt32(textBox_ClientID.Text);
                int roomNumber = Convert.ToInt32(comboBox1.SelectedValue);
                DateTime dateIn = dateTimePicker_Date_IN.Value;
                DateTime dateOut = dateTimePicker_DateOUT.Value;

                if (DateTime.Compare(dateIn.Date, DateTime.Now.Date) < 0)
                {
                    MessageBox.Show("The Date In Must Be = or greater To Today's Date", "Invalid Date In", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (DateTime.Compare(dateOut.Date, dateIn.Date) < 0)
                {
                    MessageBox.Show("The Date Out Must Be = or greater To Date In", "Invalid Date Out", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    if (reservation.editReservation(roomNumber, clientID, dateIn, dateOut))
                    {
                        room.setRoomToNo(roomNumber);
                        dataGridView1.DataSource = reservation.getAllReserv();
                        MessageBox.Show("Reservation Updated", "Edit Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                    else
                    {
                        MessageBox.Show("Reservation NOT Added", "Add Reservation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Reservation Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int clientID = Convert.ToInt32(textBox_ClientID.Text);
                int roomNumber = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString());

                if(reservation.removeReserv(clientID))
                {
                    dataGridView1.DataSource = reservation.getAllReserv();
                    room.setRoomToYes(roomNumber);
                    MessageBox.Show("Reservation Deleted", "Delete Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                else
                {
                    MessageBox.Show("Reservation Data NOT Deleted", "Delete Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Reservation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
