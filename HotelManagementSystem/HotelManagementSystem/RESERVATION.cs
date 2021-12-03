using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace HotelManagementSystem
{
    class RESERVATION
    {
        CONNECT conn = new CONNECT();

        public DataTable getAllReserv()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM hotel_db_project.reservations", conn.getConnection());



            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);


            return table;
        }

        public bool addReservation(int roomNumber, int clientID, DateTime dateIn, DateTime dateOut)
        {
            MySqlCommand command = new MySqlCommand();
            string addReservation = "INSERT INTO hotel_db_project.reservations (room_number, client_id, date_in, date_out) VALUES(@rnum,@clID,@dateIn,@dateOut)";
            command.CommandText = addReservation;
            command.Connection = conn.getConnection();

            command.Parameters.Add("@rnum", MySqlDbType.Int32).Value = roomNumber;
            command.Parameters.Add("@clID", MySqlDbType.Int32).Value = clientID;
            command.Parameters.Add("@dateIn", MySqlDbType.Date).Value = dateIn;
            command.Parameters.Add("@dateOut", MySqlDbType.Date).Value = dateOut;

            conn.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;
            }


        }


        public bool editReservation(int roomNumber, int clientID, DateTime dateIn, DateTime dateOut)
        {
            MySqlCommand command = new MySqlCommand();
            string editQuery = "UPDATE hotel_db_project.reservations SET room_number=@rnm, client_id=@clID, date_in=@DIN, date_out=@DOUT WHERE reservation_id=@reser";
            command.CommandText = editQuery;
            command.Connection = conn.getConnection();

            command.Parameters.Add("@rnm", MySqlDbType.Int32).Value = roomNumber;
            command.Parameters.Add("@clID", MySqlDbType.Int32).Value = clientID;
            command.Parameters.Add("@DIN", MySqlDbType.Date).Value = dateIn;
            command.Parameters.Add("@DOUT", MySqlDbType.Date).Value = dateOut;
            

            conn.openConnection();



            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;

            }

            else
            {
                conn.closeConnection();
                return false;
            }
        }

        public bool removeReserv(int id)
        {

            MySqlCommand command = new MySqlCommand();
            string deleteQuery = "DELETE FROM hotel_db_project.reservations WHERE reservation_id=@rID";
            command.CommandText = deleteQuery;
            command.Connection = conn.getConnection();

            command.Parameters.Add("@rID", MySqlDbType.Int32).Value = id;

            conn.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;
            }
        }



    }
}
