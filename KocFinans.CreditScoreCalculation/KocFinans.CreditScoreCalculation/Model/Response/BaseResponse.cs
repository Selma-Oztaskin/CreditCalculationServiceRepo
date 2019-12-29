using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KocFinans.CreditCalculation.Model.Response
{
    public class BaseResponse<T>
    {
        [JsonProperty("result")]
        public T Result { get; set; }


        [JsonProperty("fail")]
        public bool Fail { get; set; } = true;

        [JsonProperty("statusCode")]
        public int StatusCode { get; set; } = 0;

        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }

        [JsonProperty("errorDescription")]
        public string ErrorDescription { get; set; }

        public BaseResponse(bool Fail, int StatusCode, T Result, string ErrorCode, string ErrorDescription)
        {
            this.Fail = Fail;
            this.StatusCode = StatusCode;
            this.Result = Result;
            this.ErrorCode = ErrorCode;
            this.ErrorDescription = ErrorDescription;
        }
        public BaseResponse()
        {
            this.Fail = false;
        }
    }
}
