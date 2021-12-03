using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace HotelManagementSystem
{


    //this class will make the connection between
    //our app and mysql database
    //download connector and add to your project
    //link -> 

    class CONNECT
    {
       private MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;Uid=root;Pwd=Laguna_101");

        public MySqlConnection getConnection()
        {
            return connection;
        }

        public void openConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void closeConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }




    } 
}
