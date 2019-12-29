using KocFinans.CreditCalculation.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KocFinans.CreditCalculation.Service
{
    public interface IRuleEngine
    {
        CreditApprovalStatusResponse CreditScoreLess500();
        CreditApprovalStatusResponse CreditScoreBetween500and1000(double monthlyIncome);
        CreditApprovalStatusResponse CreditScoreEqualOrAbove1000(double monthlyIncome);
    }
}
