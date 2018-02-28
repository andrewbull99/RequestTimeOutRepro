using System;
using System.Configuration;
using System.IO;
using System.Net.Http;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = ConfigurationManager.AppSettings["UploadUrl"];
            string filePath = ConfigurationManager.AppSettings["UploadFile"];

            byte[] fileBytes = File.ReadAllBytes(filePath);

            while (true)
            {
                Console.WriteLine($"Uploading file {filePath} to {url}");

                using (var fileContent = new ByteArrayContent(fileBytes))
                using (var httpHandler = new HttpClientHandler { AllowAutoRedirect = false })
                using (var client = new HttpClient(httpHandler))
                {
                    client.Timeout = TimeSpan.FromMinutes(30);

                    HttpResponseMessage response = client.PostAsync(new Uri(url), fileContent).Result;

                    Console.WriteLine("Reponse is:\n");
                    Console.WriteLine(response);

                    Console.WriteLine("\n\nPress any key to upload again");
                    Console.ReadKey();
                }
            }
        }
    }
}
