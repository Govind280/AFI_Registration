using AFI_Registration.Business;
using AFI_Registration.Common.Models;
using AFI_Registration.Controllers;
using AFI_Registration.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace AFI_Registration.Test
{
    [TestClass]
    public class RegistrationControllerTests
    {
        private Mock<ILogger<RegistrationController>> _mockLogger;
        private Mock<IPolicyHolderRegistrationBusiness> _mockPolicyHolderRegistrationBusiness;
        private RegistrationController _registrationController;

        [TestInitialize]
        public void Init()
        {
            _mockLogger = new Mock<ILogger<RegistrationController>>();
            _mockPolicyHolderRegistrationBusiness = new Mock<IPolicyHolderRegistrationBusiness>();
            _registrationController = new RegistrationController(_mockLogger.Object, _mockPolicyHolderRegistrationBusiness.Object);
        }

        [TestMethod]
        public async Task RegisterPolicyHolder_Registered_And_CustomerID_Not_Generated()
        {
            // Arrange
            PolicyHolderDetail policyHolder = new()
            {
                FirstName = "A",
                LastName = "B",
                PolicyReferenceNumber = "aa-123456",
                DOB = DateTime.Now.AddYears(-10)
            };

            _mockPolicyHolderRegistrationBusiness.Setup(a => a.SavePolicyHolderDetails(policyHolder)).ReturnsAsync(new PolicyHolderDetails()
            {
                FirstName = policyHolder.FirstName,
                LastName = policyHolder.LastName,
                PolicyReferenceNumber = policyHolder.PolicyReferenceNumber,
                DOB = policyHolder.DOB
            });

            // Act
            var result = await _registrationController.RegisterPolicyHolder(policyHolder);

            // Assert
            BadRequestObjectResult actionResult = result as BadRequestObjectResult;
            Assert.AreEqual(400, actionResult.StatusCode);
            Assert.AreEqual("Registration failed. Please contact Administrator.", actionResult.Value);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task RegisterPolicyHolder_Registered_And_CustomerID_Generated()
        {
            // Arrange
            PolicyHolderDetail policyHolder = new()
            {
                FirstName = "John",
                LastName = "Chapel",
                PolicyReferenceNumber = "AA-123456",
                DOB = DateTime.Now.AddYears(-20)
            };

            _mockPolicyHolderRegistrationBusiness.Setup(a => a.SavePolicyHolderDetails(policyHolder)).ReturnsAsync(new PolicyHolderDetails()
            {
                FirstName = policyHolder.FirstName,
                LastName = policyHolder.LastName,
                PolicyReferenceNumber = policyHolder.PolicyReferenceNumber,
                DOB = policyHolder.DOB,
                CustomerID = 1001
            });

            // Act
            var result = await _registrationController.RegisterPolicyHolder(policyHolder);

            // Assert
            OkObjectResult actionResult = result as OkObjectResult;
            Assert.AreEqual(200, actionResult.StatusCode);
            Assert.AreEqual(1001, actionResult.Value);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
    }
}