namespace ProyectoSchedule.Common.Models
{
    using Newtonsoft.Json;
    using System;

    public class TokenResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("Expiration")]
        public DateTime Expiration { get; set; }
    }
}
