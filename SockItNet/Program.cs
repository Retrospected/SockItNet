using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 2 || args[0] != "-p")
        {
            Console.WriteLine("Usage: Program -p [port number]");
            return;
        }

        // Parse the port number from the command line argument
        int port;
        if (!int.TryParse(args[1], out port))
        {
            Console.WriteLine("Invalid port number.");
            return;
        }

        // Set up the TCP socket listener
        TcpListener server = new TcpListener(IPAddress.Any, port);
        server.Start();

        Console.WriteLine($"Listening on port {port}...");

        while (true)
        {
            // Wait for a client to connect
            TcpClient client = server.AcceptTcpClient();

            Console.WriteLine("Client connected.");

            // Get the network stream from the client
            NetworkStream stream = client.GetStream();

            // Read data from the network stream
            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                // Convert the received data to a string and print it to STDOUT
                string data = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine(data);
            }

            // Clean up
            stream.Close();
            client.Close();
            Console.WriteLine("Client disconnected.");
            break;
        }

        server.Stop();
    }
}
