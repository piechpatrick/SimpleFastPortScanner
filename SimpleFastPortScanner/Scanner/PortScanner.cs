using SimpleFastPortScanner.Ports;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFastPortScanner.Scanner
{
    internal class PortScanner
    {
        internal PortScanner(string host, Port port)
        {
            this.Port = port;
            this.Hostname = host;
        }

        internal Port Port { get; private set; }

        internal string Hostname { get; private set; }

        internal async Task<bool> CanConnect()
        {
            Socket socket = null;

            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType
                    .Stream, ProtocolType.Tcp);

                await socket.ConnectAsync(this.Hostname, this.Port.Nb);

                return true;
            }
            catch (SocketException ex)
            {
                if (ex.SocketErrorCode == SocketError.ConnectionRefused)                
                    return false;               
            }
            catch(Exception ex)
            {
                return false;
            }
            finally
            {
                if (socket?.Connected ?? false)
                {
                    socket?.Disconnect(false);
                }
                socket?.Close();
            }

            return false;
        }

    }
}
