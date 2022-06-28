using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Laboratorio14_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Miguel Inga 111 ---->");

            //Task.Run(() => GetPeopleAsync());

            Task.Run(() => PostInsertProductAsync());

            //-->
            //---->
            //------>
            //PARA ESTE LABORATORIO USE LAS APIS DESARROLLADAS EN EL LABORATORIO 13 :D
            //------>
            //---->
            //-->

            Console.WriteLine("Miguel Inga");
            Console.Read();



        }

        private static async Task GetPeopleAsync()
        {

            HttpClient client = new HttpClient();
            var people = new List<PersonResponse>();
            var urlBase = "https://localhost:44360";
            client.BaseAddress = new Uri(urlBase);
            var url = string.Concat(urlBase, "/api/People/Get");

            var response = await client.GetAsync(url);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                people = JsonConvert.DeserializeObject<List<PersonResponse>>(result);
            }
            foreach (var item in people)
            {
                Console.WriteLine(item.FullName);
                break;
            }

            //try
            //{
            //    var response = await client.GetAsync(url);
            //    Console.WriteLine(response);
            //    Console.WriteLine(url);
            //    //Console.WriteLine(response);
            //    //Console.WriteLine(response.StatusCode);
            //    if (response.StatusCode == HttpStatusCode.OK)
            //    {
            //        Console.WriteLine("2");
            //        var result = await response.Content.ReadAsStringAsync();
            //        Console.WriteLine(result);
            //        people = JsonConvert.DeserializeObject<List<PersonResponse>>(result);
            //        Console.WriteLine("3");
            //    }
            //    foreach (var item in people)
            //    {
            //        Console.WriteLine(item.FullName);
            //        break;
            //    }
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}
        }

        private static async Task PostInsertProductAsync()
        {
            HttpClient client = new HttpClient();
            var urlBase = "https://localhost:44360";
            client.BaseAddress = new Uri(urlBase);
            var url = string.Concat(urlBase, "/api/People/Insert");


            var model = new PersonRequest
            {
                FirstName = "Jhon",
                LastName = "Inga"
            };

            var request = JsonConvert.SerializeObject(model);

            var content = new StringContent(request, Encoding.UTF8, "application/json");

            var response = client.PostAsync(url, content).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {

                var result = await response.Content.ReadAsStringAsync();
                var person = JsonConvert.DeserializeObject<PersonResponse>(result);
                Console.WriteLine(person.FullName);
            }
            else
            {
                Console.WriteLine("Error Del Servicio");
            }



        }
    }
}
