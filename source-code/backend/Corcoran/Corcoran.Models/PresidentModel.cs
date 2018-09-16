using Newtonsoft.Json;
using System;

namespace Corcoran.Models
{
    public class PresidentModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("birthDate")]
        public DateTime BirthDate{ get; set; }
        [JsonProperty("birthPlace")]
        public string BirthPlace { get; set; }
        [JsonProperty("deathDate")]
        public DateTime? DeathDate { get; set; }
        [JsonProperty("deathPlace")]
        public string DeathPlace { get; set; }
    }
}
