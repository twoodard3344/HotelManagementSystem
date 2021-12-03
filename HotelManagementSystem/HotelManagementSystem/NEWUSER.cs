using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace HotelManagementSystem
{
    class NEWUSER
    {

        CONNECT conn = new CONNECT();

        public bool InsertNewUser(string username, string password)
        {

            MySqlCommand command = new MySqlCommand();
            string insertQuery = "INSERT INTO hotel_db_project.users (username, password) VALUES(@usn,@pass)";
            command.CommandText = insertQuery;
            command.Connection = conn.getConnection();

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;

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
