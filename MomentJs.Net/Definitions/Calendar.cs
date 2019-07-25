using Newtonsoft.Json;

namespace MomentJs.Net.Definitions
{
    public class Calendar
    {
        [JsonProperty("sameDay", Order = 1)] public string SameDay { get; set; }

        [JsonProperty("nextDay", Order = 2)] public string NextDay { get; set; }

        [JsonProperty("nextWeek", Order = 3)] public string NextWeek { get; set; }

        [JsonProperty("lastDay", Order = 4)] public string LastDay { get; set; }

        [JsonProperty("lastWeek", Order = 5)] public string LastWeek { get; set; }

        [JsonProperty("sameElse", Order = 6)] public string SameElse { get; set; }
    }
}