 namespace MyCustomHttpServer
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class HttpServer : IHttpServer
    {
        private bool isWorking;
        private readonly TcpListener tcpListener;

        public HttpServer()
        {
            this.tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 80);
        }

        public void Start()
        {
            this.tcpListener.Start();

            this.isWorking = true;

            Console.WriteLine("Started.");
            Thread listenerThread = new Thread(ActiveListener);
            listenerThread.Start();
        }

        public void Stop()
        {
            Console.WriteLine("Stopped.");
            this.isWorking = false;
        }

        private void ActiveListener()
        {
            while (this.isWorking)
            {
                Console.WriteLine("Running...");
                //Thread.Sleep(500);
                var client = this.tcpListener.AcceptTcpClient();
                var buffer = new byte[1024];
                var stream = client.GetStream();
                var readLength = stream.Read(buffer, 0, buffer.Length);
                var requestText = Encoding.UTF8.GetString(buffer, 0, readLength);
                Console.WriteLine(new string('=', 60));
                Console.WriteLine(requestText);
                var responseText = File.ReadAllText("index.html");
                var responseBytes = Encoding.UTF8.GetBytes(
                    "HTTP/1.0 200 Not Found" + Environment.NewLine +
                    "Content-Length: " + responseText.Length + Environment.NewLine + Environment.NewLine +
                    responseText);
                stream.Write(responseBytes);
            }
        }
    }
}