using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace UI
{
    class DataAccess
    {
        // connection object
        static string dbPath = string.Empty; 

        public void openPath(String path) {
            dbPath = @"data source = " + path;
            ExecuteQuery("");
        }


// for selection and searching


public static DataTable ExecuteQuery(string query)
        {
            // connection object
            SQLiteConnection conn = new SQLiteConnection(dbPath);
            try {
                conn.Open();
            }
            catch (System.ArgumentException e) 
            {
                MessageBox.Show("No database loaded.");
                
            }
            // command object
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            
            // datatable
            DataTable dt = new DataTable();
            
            // adapter
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }

        // insert, delete and update 
        public static int ExecuteNonQuery(string query)
        {
            // connection object
            SQLiteConnection conn = new SQLiteConnection(dbPath);
            conn.Open();

            // command object
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            return cmd.ExecuteNonQuery();
        }
    }
}
