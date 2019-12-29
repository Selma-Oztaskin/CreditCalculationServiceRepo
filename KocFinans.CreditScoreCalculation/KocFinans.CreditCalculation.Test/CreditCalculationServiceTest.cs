using KocFinans.CreditCalculation.Controllers;
using KocFinans.CreditCalculation.Model.Request;
using KocFinans.CreditCalculation.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace KocFinans.CreditCalculation.Test
{
    public class CreditCalculationServiceTest
    {
        CreditCalculationController _controller;
        private readonly IIntegrationServiceLayer _integrationServiceLayer;
        public CreditCalculationServiceTest(IIntegrationServiceLayer integrationServiceLayer)
        {
            _controller = new CreditCalculationController(_integrationServiceLayer);
            _integrationServiceLayer = integrationServiceLayer;
        }
        [Fact]
        public void CreditCalculation_WhenCalled_ReturnsOkResult()
        {
            CreditApplicationRequest request = new CreditApplicationRequest()
            {
                TCKN = "11111111111",
                FirstName = "Selma",
                LastName = "Öztaşkın",
                Phone = "05445803889",
                MonthlyIncome = 4500
            };

            var okResult = _controller.CreditCalculation(request);

            Assert.IsType<OkObjectResult>(okResult);
        }
        [Fact]
        public void CreditCalculation_WhenCalled_ReturnsBadRequest()
        {
            CreditApplicationRequest request = new CreditApplicationRequest()
            {
                TCKN = "11111111111",
                LastName = "Öztaşkın",
                Phone = "05445803889",
                MonthlyIncome = 4500
            };

            _controller.ModelState.AddModelError("FirstName", "Required");

            var badResponse = _controller.CreditCalculation(request);

            Assert.IsType<OkObjectResult>(badResponse);
        }
        [Fact]
        public void CreditCalculation_WhenCalled_ReturnsCreatedResponse()
        {
            CreditApplicationRequest request = new CreditApplicationRequest()
            {
                TCKN = "11111111111",
                FirstName = "Selma",
                LastName = "Öztaşkın",
                Phone = "05445803889",
                MonthlyIncome = 4500
            };


            var createdResponse = _controller.CreditCalculation(request);

            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }

        [Fact]

        public void Call_CreditScore_NotNull()
        {
            var tckn = "";
            var score = _integrationServiceLayer.GetCreditSkore(tckn);

            Assert.False(score is null);
        }
        [Fact]
        public void Test1()
        {

        }
    }
}
