using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MercadoPagoResponse
    {
        public string Id { get; set; }

    }

    public class ResponseData
    {
        [JsonProperty("id")]
        public string? Id { get; set; }
    }
    public class respuestaidmercadopago
    {
        public string? idpreferencia { get; set; }
    }
}
