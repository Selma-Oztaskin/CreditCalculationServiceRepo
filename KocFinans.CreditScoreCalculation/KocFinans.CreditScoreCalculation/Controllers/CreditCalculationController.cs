using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using KocFinans.CreditCalculation.Model.Request;
using KocFinans.CreditCalculation.Model.Response;
using KocFinans.CreditCalculation.Service;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace KocFinans.CreditCalculation.Controllers
{
    [Produces("application/json")]
    [Route("api/creditCalculation")]
    public class CreditCalculationController : Controller
    {
        private readonly IIntegrationServiceLayer _apiIntegratorService;

        public CreditCalculationController(IIntegrationServiceLayer apiIntegratorService)
        {
            _apiIntegratorService = apiIntegratorService;
        }

        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(BaseResponse<CreditApprovalStatusResponse>))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "No value found for requested filter.")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Request not accepted.")]
        [HttpPost("credit-calculation")]
        public IActionResult CreditCalculation([FromBody] CreditApplicationRequest request)
        {
            BaseResponse<CreditApprovalStatusResponse> response = new BaseResponse<CreditApprovalStatusResponse>();
            CreditApprovalStatusResponse creditStatus = new CreditApprovalStatusResponse();
            try
            {
                if (request!=null)
                {
                    //kredi skoru getiren servis çağırılır.
                    var creditSkore = _apiIntegratorService.GetCreditSkore(request.TCKN);
                    creditStatus = _apiIntegratorService.GetCreditStatusByRules(creditSkore.score, request);

                    if (creditStatus != null)
                    {
                        response.Result = creditStatus;
                        return Ok(response);
                    }
                    else
                    {
                        response = new BaseResponse<CreditApprovalStatusResponse>()
                        {
                            Fail = true,
                            ErrorDescription = "an error has occurred"
                        };
                        return BadRequest(response);
                    }
                }
                else
                {
                    response = new BaseResponse<CreditApprovalStatusResponse>()
                    {
                        Fail = true,
                        ErrorDescription = "request cannot be null "
                    };
                    return BadRequest(response);
                }
                
            }
            catch (Exception ex)
            {
                response = new BaseResponse<CreditApprovalStatusResponse>()
                {
                    Fail = true,
                    ErrorDescription = ex.Message
                };
                return BadRequest(response);
            }
        }
    }
}