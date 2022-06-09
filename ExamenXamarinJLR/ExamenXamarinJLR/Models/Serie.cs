using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenXamarinJLR.Models
{
    public class Serie
    {
        [JsonProperty("idSerie")]
        public int IdSerie { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public double Puntuacion { get; set; }
        public int Anyo { get; set; }
    }
}
