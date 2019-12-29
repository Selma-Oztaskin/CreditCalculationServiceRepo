using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using KocFinans.CreditCalculation.Common;
using KocFinans.CreditCalculation.Data.Model;
using KocFinans.CreditCalculation.Data.Repository;
using KocFinans.CreditCalculation.Enum;
using KocFinans.CreditCalculation.Model.Request;
using KocFinans.CreditCalculation.Model.Response;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace KocFinans.CreditCalculation.Service
{
    public class IntegrationServiceLayer : IIntegrationServiceLayer
    {

        IConfiguration _configuration;
        private readonly IRuleEngine _ruleEngine;
        private readonly CreditEndpointSettings _settings;
        private readonly IDataRepository<CustomerCreditInfo> _repository;
        private readonly ISenderNotification _senderNotification;
        public IntegrationServiceLayer(IRuleEngine ruleEngine, IConfiguration configuration, IOptions<CreditEndpointSettings> settings,
            IDataRepository<CustomerCreditInfo> repository, ISenderNotification senderNotification)
        {
            _ruleEngine = ruleEngine;
            _configuration = configuration;
            _settings = settings.Value;
            _repository = repository;
            _senderNotification = senderNotification;
        }
        public CreditScoreResponse GetCreditSkore(string tckn)
        {
            var json = JsonConvert.SerializeObject(tckn);
            return GetServiceResponse<CreditScoreResponse>(ServiceName.ScoreService, json);

        }

        //Kredi skoruna göre kuralları çalıştıran metot
        public CreditApprovalStatusResponse GetCreditStatusByRules(double score, CreditApplicationRequest creditApplicationRequest)
        {
            CreditApprovalStatusResponse response = new CreditApprovalStatusResponse();
            string ruleName = GetRuleName(score);
            //yeni kurallar eklerken projenin geliştirmeye açık olması için factory method desing paterni kullanıldı.
            switch (ruleName)
            {
                case RuleName.CreditScoreLess500:
                    response = _ruleEngine.CreditScoreLess500();
                    break;
                case RuleName.CreditScoreBetween500and1000:
                    response = _ruleEngine.CreditScoreBetween500and1000(creditApplicationRequest.MonthlyIncome);
                    break;
                case RuleName.CreditScoreEqualOrAbove1000:
                    response = _ruleEngine.CreditScoreEqualOrAbove1000(creditApplicationRequest.MonthlyIncome);
                    break;
                default:
                    break;
            }
            if (response != null)
            {
                //kullanıcı bilgilerini ve kredi durumunu database ekler.
                AddCustomerCreditInfo(response, creditApplicationRequest);
                //sms gönderim servisi projeyi çalıştırırken sms gönderim servisini yorum satırı haline getiriniz.
                SendNotification(creditApplicationRequest.Phone, response, "SMS");
            }
            return response;
        }


        public T GetServiceResponse<T>(string serviceName, string jsonRequest) where T : class
        {
            EndpointSettings endPointSettings = GetEndPointSetting(serviceName, _settings);
            HttpClientHandler clientHandler = new HttpClientHandler() { UseProxy = false };
            HttpClient client = new HttpClient(clientHandler);
            client.BaseAddress = new Uri(endPointSettings.EndPoint);
            string result = string.Empty;

            try
            {
                WebRequest request = WebRequest.Create(endPointSettings.EndPoint);
                request.Method = endPointSettings.Method;
                request.ContentType = "application/json";
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(jsonRequest);
                    streamWriter.Flush();
                    streamWriter.Close();

                    var response1 = (HttpWebResponse)request.GetResponse();
                    using (var streamReader = new StreamReader(response1.GetResponseStream()))
                    {
                        result = streamReader.ReadToEnd();
                    }
                }
                var response = JsonConvert.DeserializeObject<T>(result);
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }


  //---------Projeyi test edebilmek için yukarıdaki servis clientını yorum satırı haline getirip aşağıdaki---------
  //---------kod bloğunu açınız.--------------
            //Random random = new Random();
            //double value = random.Next(5000, 10000);
            //CreditScoreResponse response2 = new CreditScoreResponse()
            //{
            //    score = 3000
            //};
            //var info = JsonConvert.SerializeObject(response2);
            //var response = JsonConvert.DeserializeObject<T>(info);
            //return response;
        }

        //hangi kuralın çalışacağını belileyen metot
        private string GetRuleName(double score)
        {
            if (score < 5000)
            {
                return RuleName.CreditScoreLess500;
            }
            else if (score > 5000 && score < 10000)
            {
                return RuleName.CreditScoreBetween500and1000;
            }
            else if (score >= 10000)
            {
                return RuleName.CreditScoreEqualOrAbove1000;
            }
            return "";
        }
        private EndpointSettings GetEndPointSetting(string serviceName, CreditEndpointSettings settings)
        {
            var endPoint = new EndpointSettings();
            try
            {
                switch (serviceName)
                {
                    case "ScoreServiceEndpoint":
                        endPoint.Method = settings.ScoreServiceEndpoint.Method;
                        endPoint.EndPoint = settings.ScoreServiceEndpoint.EndPoint;
                        break;
                    case "SmsServiceEndpoint":
                        endPoint.Method = settings.SmsServiceEndpoint.Method;
                        endPoint.EndPoint = settings.SmsServiceEndpoint.EndPoint;
                        break;
                    default:
                        endPoint.Method = string.Empty;
                        endPoint.EndPoint = string.Empty;
                        break;
                }
                endPoint.ServiceName = serviceName;
                return endPoint;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private bool SendNotification(string phone, CreditApprovalStatusResponse creditApprovalStatus, string notificationType)
        {
            bool response = false;
            //sonraki süreçte gönderim türünün değişiminin olması halinde var olan kodun etkilenmemsi ve kodun gelişime açık
            //açık olması için desing patern kullanıldı.
            switch (notificationType)
            {
                case NotificationType.NotificationName:
                    response = _senderNotification.SmsSender(phone, creditApprovalStatus);
                    break;
                default:
                    break;
            }
            return response;
        }

        private void AddCustomerCreditInfo(CreditApprovalStatusResponse creditApprovalStatus, CreditApplicationRequest creditApplicationRequest)
        {
            CustomerCreditInfo customerCreditInfo = new CustomerCreditInfo()
            {
                FirstName = creditApplicationRequest.FirstName,
                LastName = creditApplicationRequest.LastName,
                TCKN = creditApplicationRequest.TCKN,
                Phone = creditApplicationRequest.Phone,
                CreditApprovalStatus = creditApprovalStatus.CreditApprovalStatus,
                CreditAmount = creditApprovalStatus.CreditAmount
            };
            _repository.Create(customerCreditInfo);
        }
    }
}
