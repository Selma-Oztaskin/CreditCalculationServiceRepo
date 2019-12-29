using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KocFinans.CreditCalculation.Common
{
    public class CreditEndpointSettings
    {
        public ScoreServiceEndpoint ScoreServiceEndpoint { get; set; }
        public SmsServiceEndpoint SmsServiceEndpoint { get; set; }
    }
    public class ScoreServiceEndpoint
    {
        public string EndPoint { get; set; }
        public string Method { get; set; }
        public string ServiceName { get; set; }
    }
    public class SmsServiceEndpoint
    {
        public string EndPoint { get; set; }
        public string Method { get; set; }
        public string ServiceName { get; set; }
    }
}
