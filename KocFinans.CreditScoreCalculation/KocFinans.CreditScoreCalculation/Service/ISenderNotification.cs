using KocFinans.CreditCalculation.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KocFinans.CreditCalculation.Service
{
    public interface ISenderNotification
    {
        bool SmsSender(string phone, CreditApprovalStatusResponse statusResponse);
    }
}
