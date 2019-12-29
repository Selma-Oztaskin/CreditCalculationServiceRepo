using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KocFinans.CreditCalculation.Model.Request
{
    public class CreditApplicationRequest
    {
        [JsonProperty("tckn")]
        public string TCKN { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("monthlyIncome")]
        public double MonthlyIncome { get; set; }
    }
}
