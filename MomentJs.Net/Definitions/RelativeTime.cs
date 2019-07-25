using Newtonsoft.Json;

namespace MomentJs.Net.Definitions
{
    public class RelativeTime
    {
        [JsonProperty("future", Order = 1)] public string Future { get; set; }

        [JsonProperty("past", Order = 2)] public string Past { get; set; }

        [JsonProperty("s", Order = 3)] public string Second { get; set; }

        [JsonProperty("ss", Order = 4)] public string Seconds { get; set; }

        [JsonProperty("m", Order = 5)] public string Minute { get; set; }

        [JsonProperty("mm", Order = 6)] public string Minutes { get; set; }

        [JsonProperty("h", Order = 7)] public string Hour { get; set; }

        [JsonProperty("hh", Order = 8)] public string Hours { get; set; }

        [JsonProperty("d", Order = 9)] public string Day { get; set; }

        [JsonProperty("dd", Order = 10)] public string Days { get; set; }

        [JsonProperty("M", Order = 11)] public string Month { get; set; }

        [JsonProperty("MM", Order = 12)] public string Months { get; set; }

        [JsonProperty("y", Order = 13)] public string Year { get; set; }

        [JsonProperty("yy", Order = 14)] public string Years { get; set; }
    }
}