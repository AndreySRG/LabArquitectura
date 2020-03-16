using System;
using System.Net.Http;
using BC;
using Newtonsoft.Json;

namespace Pruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Album al = TraerAlbumsExternosAsync(1);
            Console.WriteLine("nada");
        }

        private static string url = "http://jsonplaceholder.typicode.com/albums";
        public static Album TraerAlbumsExternosAsync(int id)
        {

            var cliente = new HttpClient();

            var peticion = cliente.GetAsync($"{url}/{id}").GetAwaiter().GetResult();

            if (peticion.IsSuccessStatusCode)
            {

                var texto = peticion.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                /*Album albumExterno = JsonSerializer.Deserialize<Album>(texto);*/
                Album albumExterno = JsonConvert.DeserializeObject<Album>(texto);

                return albumExterno;

            }
            else
            {
                return null;
            }

        }
    }
}
