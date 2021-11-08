namespace ProyectoSchedule.Common.Models
{
    using Newtonsoft.Json;

    public class Weekday
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("schedules")]
        public object Schedules { get; set; }
    }
}
