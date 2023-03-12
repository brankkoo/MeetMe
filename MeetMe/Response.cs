using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace MeetMe
{
    public class Response
    {
        [JsonProperty("memberId")]
        public string MebmberId { get; set; }

        [JsonProperty("autologinToken")]
        public string AutoLoginToken { get; set; }

        [JsonProperty("member")]
        public Member Member { get; set; }
        
        [JsonProperty("requestToken")]
        public string RequestToken { get; set; }

    }
}
