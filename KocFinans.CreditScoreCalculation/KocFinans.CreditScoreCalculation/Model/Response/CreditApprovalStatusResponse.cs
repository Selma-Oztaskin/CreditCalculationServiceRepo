using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KocFinans.CreditCalculation.Model.Response
{
    public class CreditApprovalStatusResponse
    {
        [JsonProperty("creditApprovalStatus")]
        public string CreditApprovalStatus { get; set; }

        [JsonProperty("creditAmount")]
        public double CreditAmount { get; set; }
    }
}
