using GrandTheftMultiplayer.Server.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using GrandTheftMultiplayer.Shared;
using LocalTelnetAdmin.Commands;

namespace LocalTelnetAdmin
{
    public class LocalTelnetAdmin : Script
    {
        TcpListener _server = null;

        static Dictionary<String, Command> registeredCommands = new Dictionary<String, Command>();

        public LocalTelnetAdmin()
        {
            API.onResourceStart += CreateTelnetServer;
        }

        public void CreateTelnetServer()
        {
            try
            {
                Int32 port = API.getResourceSetting<Int32>(API.getThisResource(), "socketport");

                if (port <= 1000)
                {
                    port = 9090;
                }

                IPAddress localAddr = IPAddress.Parse("127.0.0.1");

                _server = new TcpListener(localAddr, port);

                // Start listening for client requests.
                _server.Start();

                // Buffer for reading data
                Byte[] bytes = new Byte[256];
                String data = null;

                // Enter the listening loop. 
                while (true)
                {
                    Console.WriteLine("Telnet Open Server Connetion on: " + localAddr.ToString() + ":" + port);

                    // Perform a blocking call to accept requests. 
                    // You could also user server.AcceptSocket() here.
                    TcpClient client = _server.AcceptTcpClient();

                    String clientIp = ((IPEndPoint) client.Client.RemoteEndPoint).Address.ToString();
                    Console.WriteLine("Recieved Adminconnection from " + clientIp);

                    if (!clientIp.Equals("127.0.0.1"))
                    {
                        Console.WriteLine("Connection only allowed from LocalHost");
                        client.Close();
                    }
                    else
                    {
                        data = null;

                        // Get a stream object for reading and writing
                        NetworkStream stream = client.GetStream();

                        int i;

                        // Loop to receive all the data sent by the client. 
                        while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            // Translate data bytes to a ASCII string.
                            data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                            data = data.Trim();

                            if (data.Length > 0)
                            {
                                Console.WriteLine("Received from AdminSocket: {0}", data);
                                String[] args = data.Split(' ');
                                args[0] = args[0].ToLower();

                                if (args[0].Equals("help"))
                                {
                                    Help.SendHelp(stream);
                                }
                                else
                                {
                                    if (LocalTelnetAdmin.registeredCommands.ContainsKey(args[0]))
                                    {
                                        Command cmd = LocalTelnetAdmin.registeredCommands.Get(args[0]);

                                        args = args.Skip(1).ToArray();
                                        API.call(cmd.ClassName, cmd.MethodName, stream, args);
                                    }
                                    else
                                    {
                                        LocalTelnetAdmin.SendResponse(stream, ConsoleColors.RED + "Cmd " + args[0] + " does not exist!");
                                    }
                                }
                            }
                        }
                    }

                    // Shutdown and end connection
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                _server.Stop();
            }
        }

        public static void SendResponse(NetworkStream stream, String response)
        {
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(response + ConsoleColors.WHITE + "\n\r");
            stream.Write(msg, 0, msg.Length);
        }

        public static void RegisterNewCommand(String cmd, Command cmdDefinition)
        {
            LocalTelnetAdmin.registeredCommands.Add(cmd, cmdDefinition);
        }
    }
}