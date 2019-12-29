using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KocFinans.CreditCalculation.Model.Response;

namespace KocFinans.CreditCalculation.Service
{
    public class SenderNotification : ISenderNotification
    {
        public bool SmsSender(string phone, CreditApprovalStatusResponse statusResponse)
        {
            throw new NotImplementedException();
        }
    }
}
