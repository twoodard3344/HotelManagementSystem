using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace HotelManagementSystem
{
    class Room

    {
        CONNECT conn = new CONNECT();


        public DataTable roomTypeList()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM hotel_db_project.room_category", conn.getConnection());



            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);


            return table;

        }


        public DataTable roomByType(int type)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM hotel_db_project.rooms WHERE type=@type and free='YES'",conn.getConnection());

            command.Parameters.Add("@type", MySqlDbType.Int32).Value = type;

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);


            return table;

        }






        public DataTable GetRoomList()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM hotel_db_project.rooms", conn.getConnection());

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
           
        }

        public bool addRoom(int number, int type, string phone, string free)
        {
            MySqlCommand command = new MySqlCommand();
            string addRoomQuery = "INSERT INTO hotel_db_project.rooms (number, type, phone, free) VALUES(@num,@type,@phn,@free)";
            command.CommandText = addRoomQuery;
            command.Connection = conn.getConnection();

            command.Parameters.Add("@num", MySqlDbType.Int32).Value = number;
            command.Parameters.Add("@type", MySqlDbType.Int32).Value = type;
            command.Parameters.Add("@phn", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@free", MySqlDbType.VarChar).Value = free;

            conn.openConnection();

            if (command.ExecuteNonQuery()==1)
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

        public bool editRoom(int number, int type, string phone, string free)
        {
            MySqlCommand command = new MySqlCommand();
            string editQuery = "UPDATE hotel_db_project.rooms SET type=@type, phone=@phn, free=@free WHERE number=@num";
            command.CommandText = editQuery;
            command.Connection = conn.getConnection();

            command.Parameters.Add("@type", MySqlDbType.Int32).Value = type;
            command.Parameters.Add("@phn", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@free", MySqlDbType.VarChar).Value = free;
            command.Parameters.Add("@num", MySqlDbType.Int32).Value = number;

            conn.openConnection();

            if(command.ExecuteNonQuery() == 1)
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

        public bool removeRoom(int number)
        {
            MySqlCommand command = new MySqlCommand();
            string deleteQuery = "DELETE FROM hotel_db_project.rooms WHERE number=@num";
            command.CommandText = deleteQuery;
            command.Connection = conn.getConnection();

            command.Parameters.Add("@num", MySqlDbType.Int32).Value = number;

            conn.openConnection();

            if(command.ExecuteNonQuery()==1)
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

        public bool setRoomToNo(int number)
        {
            MySqlCommand command = new MySqlCommand("UPDATE hotel_db_project.rooms SET free='NO' WHERE number=@number", conn.getConnection());

            command.Parameters.Add("@number", MySqlDbType.Int32).Value = number;

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);

            conn.openConnection();

            if (command.ExecuteNonQuery() >=1)
            {
                conn.closeConnection();
                return false;
            }
            else
            {
                conn.closeConnection();
                return true;
            }

           
            

        }

        public bool setRoomToYes(int number)
        {
            MySqlCommand command = new MySqlCommand("UPDATE hotel_db_project.rooms SET free='YES' WHERE number=@number", conn.getConnection());

            command.Parameters.Add("@number", MySqlDbType.Int32).Value = number;

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);

            conn.openConnection();

            if (command.ExecuteNonQuery() >= 1)
            {
                conn.closeConnection();
                return false;
            }
            else
            {
                conn.closeConnection();
                return true;
            }




        }



    }
}
