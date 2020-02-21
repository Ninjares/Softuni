using System;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientt
{
    class Program
    {

        //typescript
        //Rust
        //WebAssembly
        //JavaScript
        static void Main(string[] args)
        {
            TcpListener listener = new TcpListener(IPAddress.Loopback, 27020);
            listener.Start();
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient(); //the readline of the tcplistener - just waits until it receives
                NetworkStream stream = client.GetStream();
                //TODO: use buffer
                byte[] requestbytes = new byte[1000000];
                stream.Read(requestbytes, 0, requestbytes.Length);
                string request = Encoding.UTF8.GetString(requestbytes);
                Console.WriteLine(request);
                Console.WriteLine(new string('=', 75));
                    
            }
        }

        public static async Task ReadHtttpRequest()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://softuni.bg/");
            string str = await response.Content.ReadAsStringAsync();
            Console.WriteLine(str);
        }
    }
}
