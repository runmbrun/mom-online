
#region Using Statements
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.Reflection;
using System.Threading;
using System.Net;
using System.Net.Sockets;
#endregion



namespace MOM
{
    public partial class MOMService : ServiceBase
    {

        #region Private Variables

        // Debug vars
        public Boolean Debug = false;

        // DB vars
        MOMDatabase MOMDB;

        // Error Handling vars
        private String _servicePath;
        private String[] _errorMessages;
        private Int32 _errorCount;

        // Network vars
        private Int32 _port = 4545;
        byte[] byteData = new byte[1024];

        //The ClientInfo structure holds the required information 
        // about every client connected to the server
        struct ClientInfo
        {
            //Socket of the client
            public Socket Socket;
            
            //Name by which the user logged into the chat room
            public String Player;
        }

        //The collection of all clients logged 
        //into the room (an array of type ClientInfo)
        ArrayList ClientList = null;
        
        //The main socket on which the server listens to the clients
        Socket serverSocket;        

        #endregion


        /// <summary>
        /// This is the constructor for the BuildService Class
        /// </summary>
        public MOMService()
        {
            InitializeComponent();

            // this is the string array of all the errors found during processing
            _errorMessages = new String[128];
            _errorMessages.Initialize();
            _errorCount = 0;

            try
            {
                // start the Event Logger
                if (!System.Diagnostics.EventLog.SourceExists("MOM Service"))
                {
                    System.Diagnostics.EventLog.CreateEventSource("MOM Service", "MOM Service Log");
                }
            }
            catch (Exception ex)
            {
                AddError(ex.Message);
            }

            //this.EventLog.Source
            eventLog1.Source = "MOM Service";
            eventLog1.Log = "MOM Service Log";
            
            // get the current folder the app is running in and save it            
            _servicePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);

            if (_servicePath == "")
            {
                _servicePath = "c:\\temp\\";
                AddError(String.Format("ERROR: Can't find the path of the running EXE: "));
            }
            else
            {
                _servicePath += "\\";
            }

            // check to see if this is a debug version
#if DEBUG
            Debug = true;
#endif

            // read the Config file
            if (!ReadConfig())
            {
                // error!
                AddError(String.Format("ERROR: Unable to read the config file"));
            }

            ClientList = new ArrayList();
        }
        
        /// <summary>
        /// This function will read in a config file if it exists
        /// </summary>
        /// <returns></returns>
        public bool ReadConfig()
        {
            Boolean Read = false;

            Read = true;

            return Read;
        }

        /// <summary>
        /// This is the function that is called when this app is run as a service.
        /// This is the Start method of the Service.
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            try
            {
                eventLog1.WriteEntry("MOM Service is now Starting");
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("MOM Service failed while trying to start: " + ex.Message);
            }

            // This is the new code that will start this service listening on a specific TCP port
            try
            {
                //We are using TCP sockets
                serverSocket = new Socket(AddressFamily.InterNetwork,
                                          SocketType.Stream,
                                          ProtocolType.Tcp);

                //Assign the any IP of the machine and listen on port number 1000
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, _port);

                //Bind and listen on the given address
                serverSocket.Bind(ipEndPoint);
                serverSocket.Listen(4);

                //Accept the incoming clients
                serverSocket.BeginAccept(new AsyncCallback(OnAccept), null);
            }
            catch (Exception ex)
            {
                AddError(String.Format("OnStart: Server TCP {0}", ex.Message));
            }

            // database connection initialization
            MOMDB = new MOMDatabase();
            if (!MOMDB.Connect())
            {
                // error!
                AddError(String.Format("ERROR: Unable to connect to the database. {0}", MOMDB.GetLastError));
            }
        }

        /// <summary>
        /// This is the function that is called when this app is run as a service.
        /// This is the Stop method of the Service.
        /// </summary>
        protected override void OnStop()
        {
            try
            {
                eventLog1.WriteEntry("MOM Service is Stopping");
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("MOM Service failed while try to stop the service: " + ex.Message);
            }

             // close all the network clients talking to this server
            if (ClientList != null)
            {
                foreach (ClientInfo client in ClientList)
                {
                    client.Socket.Close();
                }
            }

            // close down the database connection
            if (MOMDB.Connected)
            {
                if (MOMDB.Disconnect())
                {
                    // error!
                    AddError(String.Format("ERROR: Unable to disconnect to the database. {0}", MOMDB.GetLastError));
                }
            }
        }

        #region Test OnStart and OnStop Functions

        /// <summary>
        /// This function is called by the TestBuilder app to trick the BuilderService into
        /// thinking it is running as a service.
        /// This is the Start method of the Service.
        /// </summary>
        /// <param name="args"></param>
        public void TestOnStart(string[] args)
        {
            OnStart(args);
        }

        /// <summary>
        /// This function is called by the TestBuilder app to trick the BuilderService into
        /// thinking it is running as a service.
        /// This is the Stop method of the Service.
        /// </summary>        
        public void TestOnStop()
        {
            OnStop();
        }
        #endregion

        /// <summary>
        /// Adds an error string to the errors string array
        /// </summary>
        /// <param name="strErrorMessage"></param>
        private void AddError(String ErrorMessage)
        {
            _errorMessages[_errorCount++] = ErrorMessage;
            // mmb - need to write this to a log file too!
        }

        /// <summary>
        /// When a connection is accepted, this function is called
        /// </summary>
        /// <param name="ar"></param>
        private void OnAccept(IAsyncResult ar)
        {
            try
            {
                Socket clientSocket = serverSocket.EndAccept(ar);

                //Start listening for more clients
                serverSocket.BeginAccept(new AsyncCallback(OnAccept), null);

                //Once the client connects then start receiving the commands from them
                clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnReceive), clientSocket);
            }
            catch (Exception ex)
            {
                String.Format("OnAccept: {0}", ex.Message);
            }
        }

        /// <summary>
        /// When a packet is received, this function is called
        /// </summary>
        /// <param name="ar"></param>
        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                Socket clientSocket = (Socket)ar.AsyncState;
                clientSocket.EndReceive(ar);

                ClientInfo clientInfo;
                byte[] message = null;
                String User = "Player [Unknown] ";

                
                //Transform the array of bytes received from the user into an
                //intelligent form of object Data
                MOMNetworkPacket msgReceived = new MOMNetworkPacket(byteData);
                MOMNetworkPacket msgToSend = new MOMNetworkPacket();
                                
                
                //If the message is to login, logout, or simple text message
                //then when send to others the type of the message remains the same
                switch (msgReceived.OpCode)
                {
                    // *** Login ***
                    case MOMNetworkPacket.MOMOpCode.Login:

                        Int32 result = 0;

                        // verify that this user can log on
                        String data = msgReceived.Data.ToString();
                        String user = data.Substring(0, data.IndexOf(":"));
                        String pass = data.Substring(data.IndexOf(":") + 1);

                        // now check the user against the database...
                        if (MOMDB.ValidateUser(user, pass))
                        {   
                            result = 1;

                            if (MOMDB.IsAdmin(user, pass))
                            {
                                result += 1;
                            }
                        }

                        //When a user logs in to the server then we add them to our list of clients
                        clientInfo = new ClientInfo();
                        clientInfo.Socket= clientSocket;
                        clientInfo.Player = user;
                        ClientList.Add(clientInfo);

                        // Send back a login packet to the user to tell them if user was validate against db
                        msgToSend.OpCode = MOMNetworkPacket.MOMOpCode.Login;
                        msgToSend.Data = result;

                        message = msgToSend.ToByte();

                        clientSocket.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(OnSend), clientSocket);

                        // this player isn't a valid player, so disconnect the client
                        if (result == 0)
                        {
                            // error, just disconnect this connection
                            foreach (ClientInfo client in ClientList)
                            {
                                if (client.Socket == clientSocket)
                                {
                                    // remove this user from the client list
                                    ClientList.Remove(client);
                                    break;
                                }
                            }
                        }
                        else
                        {

                            // mmb - todo
                            // save data like online field, login time, etc

                            //Send the name of the users in the chat room... User has logged in.
                            // Send back a login packet to the user to tell them if user was validate against db
                            msgToSend.OpCode = MOMNetworkPacket.MOMOpCode.Chat;
                            msgToSend.Data = "Player [" + user + "] is now online";
                            message = msgToSend.ToByte();
                            foreach (ClientInfo client in ClientList)
                            {
                                client.Socket.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(OnSend), client.Socket);
                            }
                            
                            // Query DB to get Player's collection and send it back to that client
                            String Stats = MOMDB.GetPlayerStats(user);
                            if (Stats != "")
                            {
                                // send the collection data for this user to his client  
                                msgToSend.OpCode = MOMNetworkPacket.MOMOpCode.ReceivePlayerStats;
                                msgToSend.Data = Stats;
                                message = msgToSend.ToByte();
                                clientSocket.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(OnSend), clientSocket);
                            }
                        }                        

                        break;
                        
                    // *** Logout ***
                    case MOMNetworkPacket.MOMOpCode.Logout:

                        // mmb - todo
                        // save data like online field, logout time, etc

                        // send an acknowledgement logout message back to client
                        msgToSend.OpCode = MOMNetworkPacket.MOMOpCode.Logout;
                        msgToSend.Data = "1";

                        message = msgToSend.ToByte();

                        clientSocket.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(OnSendAndClose), clientSocket);


                        //Send the name of the users in the chat room... User has logged in.
                        // Send back a login packet to the user to tell them if user was validate against db
                        msgToSend.OpCode = MOMNetworkPacket.MOMOpCode.Chat;
                        
                        foreach (ClientInfo client in ClientList)
                        {
                            if (client.Socket == clientSocket)
                            {
                                User = "Player ["+ client.Player + "] ";
                            }
                        }
                        msgToSend.Data = "Player [" + User + "] is offline";
                        message = msgToSend.ToByte();


                        //When a user wants to log out of the server then we search for her 
                        //in the list of clients and close the corresponding connection
                        foreach (ClientInfo client in ClientList)
                        {
                            if (client.Socket == clientSocket)
                            {
                                // remove user from client list
                                ClientList.Remove(client);
                                break;
                            }
                            else
                            {
                                //Send the name of this logged out player to all the players in the chat room... 
                                client.Socket.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(OnSend), client.Socket);
                            }
                        }

                        // break the network connection with the client
                        clientSocket.Close();

                        break;
                        
                    // *** Chat ***
                    case MOMNetworkPacket.MOMOpCode.Chat:
                        
                        // First, get the string 
                        String ChatData = msgReceived.Data.ToString();

                        // now find out the player's name
                        foreach (ClientInfo client in ClientList)
                        {
                            if (client.Socket == clientSocket)
                            {
                                // this is the player, collect the name
                                User = "[" + client.Player + "] ";
                            }
                        }

                        // Check to see if this is a command
                        // examples:
                        // /who
                        // /help
                        // /commands
                        // /friends
                        if (ChatData.StartsWith("/"))
                        {
                            String Outbound = "UNKOWN";


                            switch (ChatData.Substring(1).ToUpper())
                            {
                                case "WHO":
                                    // list all the online players
                                    // mmb - TODO
                                    Outbound = "An unknown number of people are online";
                                    break;
                                default:
                                    Outbound = "Unknown Command";
                                    break;
                            }

                            // Create the outgoing chat packet
                            msgToSend.OpCode = MOMNetworkPacket.MOMOpCode.Chat;
                            msgToSend.Data = Outbound;
                            message = msgToSend.ToByte();
                            clientSocket.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(OnSend), clientSocket);
                        }
                        else
                        {
                            // This is just a normal chat message, so send it to all the other online players

                            // Create the outgoing chat packet
                            msgToSend.OpCode = MOMNetworkPacket.MOMOpCode.Chat;
                            msgToSend.Data = User + ChatData;

                            message = msgToSend.ToByte();

                            foreach (ClientInfo client in ClientList)
                            {
                                // send chat message back to other players
                                // including the player who sent it
                                client.Socket.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(OnSend), client.Socket);
                            }
                        }

                        break;

                    // *** Catchall...
                    default:
                        // record this because it shouldn't be happening
                        AddError(String.Format("OnReceive: Unknown Packet Recieved. {0}", msgReceived.OpCode));
                        break;
                }

                //If the user is logging out then we need not listen from her
                if (msgReceived.OpCode != MOMNetworkPacket.MOMOpCode.Logout)
                {
                    //Start listening to the message send by the user
                    clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnReceive), clientSocket);
                }
            }
            catch (Exception ex)
            {
                AddError(String.Format("OnReceive: {0}", ex.Message));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ar"></param>
        public void OnSend(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;
                client.EndSend(ar);
            }
            catch (Exception ex)
            {
                AddError(String.Format("OnSend: {0}", ex.Message));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ar"></param>
        private void OnSendAndClose(IAsyncResult ar)
        {
            try
            {
                // message was successfully sent
                Socket client = (Socket)ar.AsyncState;
                client.EndSend(ar);
                client.Close();
            }
            catch (ObjectDisposedException exo)
            {
                AddError("OnSendAndClose:  Unable to send message to the server. ObjectDisposed.  [" + exo.Message + "]");
            }
            catch (Exception ex)
            {
                AddError("OnSendAndClose:  Unable to send message to the server. [" + ex.Message + "]");
            }
        }



        #region Unused Code - This code will eventually be deleted, but can't be just yet...
        /*
                                int nIndex = 0;
                        foreach (ClientInfo client in clientList)
                        {
                            if (client.socket == clientSocket)
                            {
                                clientList.RemoveAt(nIndex);
                                break;
                            }
                            ++nIndex;
                        }

        */
        #endregion
    }
}

