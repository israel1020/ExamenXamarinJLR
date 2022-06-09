using ExamenXamarinJLR.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ExamenXamarinJLR.Services
{
    public class ServiceSeries
    {
        private string ApiUrl;
        private MediaTypeWithQualityHeaderValue Header;
        public ServiceSeries(IConfiguration configuration)
        {
            this.ApiUrl = configuration["ApiUrl:Series"];
            this.Header = new MediaTypeWithQualityHeaderValue("application/json");
        }
        private async Task<T> CallApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri(this.ApiUrl + request);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                HttpResponseMessage response =
                    await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    T data =
                        await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }
        public async Task<List<Serie>> GetSeriesAsync()
        {
            string request = "/api/Series";
            List<Serie> series = await this.CallApiAsync<List<Serie>>(request);
            return series;
        }
        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            string request = "/api/Personajes";
            List<Personaje> personajes = await this.CallApiAsync<List<Personaje>>(request);
            return personajes;
        }
        public async Task<List<Personaje>> FindPersonajesSeriesAsyn(int idserie)
        {
            string request = "/api/Series/PersonajesSerie/" + idserie;
            List<Personaje> personajes = await this.CallApiAsync<List<Personaje>>(request);
            return personajes;
        }
        private async Task<int> IdPersonajeMax()
        {
            List<Personaje> personajes = await this.GetPersonajesAsync();
            return personajes.Max(x => x.IdPersonaje) + 1;
        }
        public async Task InsertarPersonaje(string nombre, string imagen, int idserie)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                Personaje personaje = new Personaje();
                personaje.IdPersonaje = await this.IdPersonajeMax();
                personaje.Nombre = nombre;
                personaje.Imagen = imagen;
                personaje.IdSerie = idserie;
                string json = JsonConvert.SerializeObject(personaje);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                string request = "/api/personajes";
                Uri uri = new Uri(this.ApiUrl + request);
                await client.PostAsync(uri, content);
            }
        }
        public async Task UpdateDepartamentoAsync(Personaje personaje)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                string json = JsonConvert.SerializeObject(personaje);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                string request = "/api/personajes";
                Uri uri = new Uri(this.ApiUrl + request);
                await client.PutAsync(uri, content);
            }
        }
    }
}
