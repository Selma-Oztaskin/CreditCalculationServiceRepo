using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KocFinans.CreditCalculation.Enum;
using KocFinans.CreditCalculation.Model.Response;

namespace KocFinans.CreditCalculation.Service
{
    public class RuleEngine : IRuleEngine
    {

        public CreditApprovalStatusResponse CreditScoreBetween500and1000(double monthlyIncome)
        {
            CreditApprovalStatusResponse response = new CreditApprovalStatusResponse();
            if (monthlyIncome < 5000)
            {
                response.CreditApprovalStatus = Constants.Positive;
                response.CreditAmount = 10000;
            }
            else
            {
                response.CreditApprovalStatus = Constants.Positive;
                response.CreditAmount = (monthlyIncome * LimitMultiplier.LimitMultiplierValue);
            }

            return response;
        }

        public CreditApprovalStatusResponse CreditScoreEqualOrAbove1000(double monthlyIncome)
        {
            CreditApprovalStatusResponse response = new CreditApprovalStatusResponse()
            {
                CreditApprovalStatus = Constants.Positive,
                CreditAmount = (monthlyIncome * LimitMultiplier.LimitMultiplierValue)
            };
            return response;
        }

        public CreditApprovalStatusResponse CreditScoreLess500()
        {
            CreditApprovalStatusResponse response = new CreditApprovalStatusResponse()
            {
                CreditApprovalStatus = Constants.Negative,
                CreditAmount = 0
            };
            return response;
        }
    }
}
