using KocFinans.CreditCalculation.Model.Request;
using KocFinans.CreditCalculation.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KocFinans.CreditCalculation.Service
{
    public interface IIntegrationServiceLayer
    {
        T GetServiceResponse<T>(string serviceName, string jsonRequest) where T : class;
        CreditScoreResponse GetCreditSkore(string tckn);

        CreditApprovalStatusResponse GetCreditStatusByRules(double score, CreditApplicationRequest creditApplicationRequest);
    }
}
