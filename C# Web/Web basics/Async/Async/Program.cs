using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Async
{
    class Program
    {
      
        static async Task Main(string[] args)
        {
            //async - suggests that the function may be run in parallel
            //await - do whatever the function is and when it's done continue
            try
            {
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync("https://softuni.bg/");
                var result = await httpResponse.Content.ReadAsStringAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            Console.ReadKey();
            
            int i = 0;
            var t = Task.Run(() =>
            {
                int start = i;
                while (i < start + 10000) i++;
                return i;
            });
            Task task = new Task(async () =>
            {
                int start = i;
                while (i < start + 10000) i++;
                return i;
            });
            task.Start();
        }
        static async Task func(int i)
        {
            
        }
    }
}
