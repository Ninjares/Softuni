using System;

namespace MyCustomHttpServer
{
    public static class StartUp
    {
        public static void Main(string[] args)
        {
            IHttpServer server = new HttpServer();
            server.Start();
            Console.ReadLine();
            server.Stop();
        }
    }
}