using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Vivenu_API_Test.Model;

namespace Vivenu_API_Test
{
    internal class Program
    {
        private const string URL = "https://vivenu.com/api";
        private const string TOKEN = "key_<getyourown>";

        static void Main(string[] args)
        {
            // Basic information
            // Docs: https://docs.vivenu.dev/
            // Base - URL: https://vivenu.com/api/
            // Authentication via Bearer Token API_KEY (Create it from dashboard)

            // Get all customers sample
            GetAllCustomers();

            // Create Customer
            CreateCustomer();

            // Get all customers again
            GetAllCustomers();

        }

        private static void CreateCustomer() {
            string url = $"{URL}/customers";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";

            httpRequest.Accept = "application/json";
            httpRequest.Headers["Authorization"] = $"Bearer {TOKEN}";
            httpRequest.ContentType = "application/json";
            
            // The documentation says that primary mail is enough
            // This is not the case at 03/21/2022
            var data = @"{
                ""prename"": ""Tom"",
                ""lastname"": ""Tester"",
                ""primaryEmail"": ""trash12345@temptrash.com"",
                ""location"": {
                    ""street"": ""Test 1234"",
                    ""postal"": ""03096"",
                    ""city"": ""Burg"",
                    ""locale"": ""Germany"",
                    ""state"": ""Brandenburg"",
                    ""country"": ""DE""
                }
            }";

            // ToDo: Use Model instead

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(data);
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream() ?? throw new InvalidOperationException()))
            {
                var result = streamReader.ReadToEnd();
                Console.WriteLine(result);
            }

            Console.WriteLine(httpResponse.StatusCode);
        }

        private static void GetAllCustomers() {

            string url = $"{URL}/customers/rich";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "GET";

            httpRequest.Accept = "application/json";
            httpRequest.Headers["Authorization"] = $"Bearer {TOKEN}";
            httpRequest.ContentType = "";



            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream() ?? throw new InvalidOperationException())) {
                var result = streamReader.ReadToEnd();
                Console.WriteLine(result);
            }

            Console.WriteLine(httpResponse.StatusCode);
        }
    }
}
