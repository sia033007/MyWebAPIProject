using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMVCProject.Models
{
    public class JWTToken
    {
        [JsonProperty("token")]
        public string token { get; set; }
        [JsonProperty("expireAt")]
        public DateTime expireAt { get; set; }
    }
}
