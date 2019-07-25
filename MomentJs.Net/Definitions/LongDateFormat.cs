using Newtonsoft.Json;

namespace MomentJs.Net.Definitions
{
    public class LongDateFormat
    {
        [JsonProperty("LT", Order = 1)] public string LT { get; set; }

        [JsonProperty("LTS", Order = 2)] public string LTS { get; set; }

        [JsonProperty("L", Order = 3)] public string L { get; set; }

        [JsonProperty("LL", Order = 4)] public string LL { get; set; }

        [JsonProperty("LLL", Order = 5)] public string LLL { get; set; }

        [JsonProperty("LLLL", Order = 6)] public string LLLL { get; set; }

        [JsonIgnore] public string l { get; set; }

        [JsonIgnore] public string ll { get; set; }

        [JsonIgnore] public string lll { get; set; }

        [JsonIgnore] public string llll { get; set; }
    }
}