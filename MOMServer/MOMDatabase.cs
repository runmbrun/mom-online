﻿
#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
#endregion



namespace MOM
{
    class MOMDatabase
    {   
        #region Database Vars
        private String server = "127.0.0.1";
        private String user = "sa";
        private String password = "Password01";
        private String name = "mom";
        #endregion

        #region Vars
        SqlConnection sqlConn;
        private String connectionstring;
                
        private Boolean connected = false;
        public Boolean Connected
        {
            get { return connected; }
        }
        
        private String errorstring;
        public String GetLastError
        {
            get { return errorstring; }
        }
        #endregion



        /// <summary>
        /// 
        /// </summary>
        public MOMDatabase()
        {
            connectionstring = "server=" + server + ";uid=" + user + ";pwd=" + password + ";database=" + name + ";";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Boolean Connect()
        {
            try
            {
                // create a new SqlConnection object with the appropriate connection string
                sqlConn = new SqlConnection(connectionstring);

                // open the connection
                sqlConn.Open();

                connected = true;
            }
            catch (Exception ex)
            {
                errorstring = String.Format("MOMDatabase ERROR: Failed to connect. [{0}]", ex.Message);
            }

            return Connected;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Boolean Disconnect()
        {
            Boolean Success = false;
            try
            {
                if (Connected)
                {
                    // close the connection
                    sqlConn.Close();
                }

                connected = false;
                Success = true;
            }
            catch (Exception ex)
            {
                errorstring = String.Format("MOMDatabase ERROR: Failed to connect. [{0}]", ex.Message);
            }

            return Success;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="User"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public Boolean ValidateUser(String User, String Password)
        {
            Boolean Valid = false;
            Int32 Count = 0;
            String sql = "SELECT * FROM players WHERE name='" + User + "' and password='" + Password + "'";
            SqlCommand sqlComm;


            try
            {
                // create the command object
                sqlComm = new SqlCommand(sql, sqlConn);
                //Count = sqlComm.ExecuteScalar(); //mmb - this fails right now... why?  Or is it needed?

                SqlDataReader r = sqlComm.ExecuteReader();
                while (r.Read())
                {
                    string username = (string)r["name"];
                    int userID = (int)r["id"];
                    Count++;
                }
                r.Close();
            }
            catch (Exception ex)
            {
                errorstring = String.Format("MOMDatabase ERROR: DB Query in ValidateUser. [{0}]", ex.Message);
            }

            if (Count == 1)
            {
                Valid = true;
            }
            else
            {
                errorstring = String.Format("MOMDatabase ERROR: Invalid User. Count=[{0}]", Count);
            }            

            return Valid;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="User"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public Boolean IsAdmin(String User, String Password)
        {
            Boolean Admin = false;
            SqlCommand sqlComm;
            Int32 Count = 0;


            try
            {
                // create the command object
                sqlComm = new SqlCommand("SELECT * FROM players WHERE name='" + User + "' and password='" + Password + "' and admin = 1", sqlConn);

                SqlDataReader r = sqlComm.ExecuteReader();
                while (r.Read())
                {
                    string username = (string)r["name"];
                    int userID = (int)r["id"];
                    Count++;
                }
                r.Close();
            }
            catch (Exception ex)
            {
                errorstring = String.Format("MOMDatabase ERROR: DB Query in IsAdmin. [{0}]", ex.Message);
            }

            if (Count == 1)
            {
                Admin = true;
            }
            else
            {
                errorstring = String.Format("MOMDatabase ERROR: Non Admin User. Count=[{0}]", Count);
            }

            return Admin;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public String GetPlayerStats(String Player)
        {
            String Stats = "STATS";


            // mmb - todo

            return Stats;            
        }
    }
}
