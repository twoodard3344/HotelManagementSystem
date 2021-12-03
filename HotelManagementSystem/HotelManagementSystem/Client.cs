using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace HotelManagementSystem
{
    class Client
    {

        CONNECT conn = new CONNECT();

        



        public bool InsertClient(string fname, string lname, string phoneNo, string state)
        {
            
            MySqlCommand sqlCommand = new MySqlCommand();
            string insertQuery = "INSERT INTO hotel_db_project.clients (first_name,last_name,phone_number,state) VALUES (@fnm, @lnm,@phn,@state)";
            sqlCommand.CommandText = insertQuery;
            sqlCommand.Connection = conn.getConnection();


            sqlCommand.Parameters.Add("@fnm", MySqlDbType.VarChar).Value = fname;
            sqlCommand.Parameters.Add("@lnm", MySqlDbType.VarChar).Value = lname;
            sqlCommand.Parameters.Add("@phn", MySqlDbType.VarChar).Value = phoneNo;
            sqlCommand.Parameters.Add("@state", MySqlDbType.VarChar).Value = state;

            conn.openConnection();

            if (sqlCommand.ExecuteNonQuery() == 1)
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


        public DataTable GetClients()
        {


            MySqlCommand command = new MySqlCommand("SELECT * FROM hotel_db_project.clients",conn.getConnection());



            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);


            return table;
        }

        public bool editClient(int id,string fname, string lname, string phoneNo, string state)
        {

            MySqlCommand sqlCommand = new MySqlCommand();
            string editQuery = "UPDATE hotel_db_project.clients SET  first_name= @fnm, last_name = @lnm, phone_number = @phn, state = @state WHERE id=@cid";
            sqlCommand.CommandText = editQuery;
            sqlCommand.Connection = conn.getConnection();

            sqlCommand.Parameters.Add("@cid", MySqlDbType.Int32).Value = id;
            sqlCommand.Parameters.Add("@fnm", MySqlDbType.VarChar).Value = fname;
            sqlCommand.Parameters.Add("@lnm", MySqlDbType.VarChar).Value = lname;
            sqlCommand.Parameters.Add("@phn", MySqlDbType.VarChar).Value = phoneNo;
            sqlCommand.Parameters.Add("@state", MySqlDbType.VarChar).Value = state;

            conn.openConnection();

            if (sqlCommand.ExecuteNonQuery() == 1)
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

        public bool DeleteClient(int id)
        {

            MySqlCommand sqlCommand = new MySqlCommand();
            string deleteQuery = "DELETE FROM hotel_db_project.clients WHERE id=@cid";
            sqlCommand.CommandText = deleteQuery;
            sqlCommand.Connection = conn.getConnection();

            sqlCommand.Parameters.Add("@cid", MySqlDbType.Int32).Value = id;
            

            conn.openConnection();

            if(sqlCommand.ExecuteNonQuery() == 1)
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
