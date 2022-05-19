using AFI_Registration.Models;
using AFI_Registration.Validator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace AFI_Registration.Test
{
    [TestClass]
    public class PolicyHolderDetailsValidatorTests
    {
        [TestMethod]
        public void PolicyHolder_HasRequired_Fields_Invalid_Details()
        {
            // Arrange
            PolicyHolderDetail policyHolder = new() {
                FirstName = "A",
                LastName = "B",
                PolicyReferenceNumber = "aa-123456",
                DOB = DateTime.Now.AddYears(-10)
            };
            var validator = new PolicyHolderDetailsValidator();

            // Act
            var result = validator.Validate(policyHolder);

            // Assert
            Assert.IsFalse(result.IsValid);
            Assert.IsNotNull(result.Errors);
            Assert.AreEqual(4, result.Errors.Count);
            Assert.IsTrue(result.Errors.Any(r => r.ErrorMessage.Equals("Policy Holder First name should be between 3 to 50 characters.")));
            Assert.IsTrue(result.Errors.Any(r => r.ErrorMessage.Equals("Policy Holder Last name should be between 3 to 50 characters.")));
            Assert.IsTrue(result.Errors.Any(r => r.ErrorMessage.Equals("Policy Reference Number should have 2 alphabets in capital followed by 6 digits in AA-999999 format.")));
            Assert.IsTrue(result.Errors.Any(r => r.ErrorMessage.Equals("Policy holder age should be 18 years or above.")));
        }

        [TestMethod]
        public void PolicyHolder_MisingRequired_Fields()
        {
            // Arrange
            PolicyHolderDetail policyHolder = new();
            var validator = new PolicyHolderDetailsValidator();

            // Act
            var result = validator.Validate(policyHolder);

            // Assert
            Assert.IsFalse(result.IsValid);
            Assert.IsNotNull(result.Errors);
            Assert.AreEqual(3, result.Errors.Count);
            Assert.IsTrue(result.Errors.Any(r => r.ErrorMessage.Equals("Policy Holder First name is Mandatory.")));
            Assert.IsTrue(result.Errors.Any(r => r.ErrorMessage.Equals("Policy Holder Last name is Mandatory.")));
            Assert.IsTrue(result.Errors.Any(r => r.ErrorMessage.Equals("Policy Reference Number is Mandatory.")));
        }

        [TestMethod]
        public void PolicyHolder_HasRequired_Fields_Valid_Details()
        {
            // Arrange
            PolicyHolderDetail policyHolder = new()
            {
                FirstName = "John",
                LastName = "Chapel",
                PolicyReferenceNumber = "AA-123456",
                DOB = DateTime.Now.AddYears(-20)
            };
            var validator = new PolicyHolderDetailsValidator();

            // Act
            var result = validator.Validate(policyHolder);

            // Assert
            Assert.IsTrue(result.IsValid);
            Assert.AreEqual(0, result.Errors.Count);
        }
    }
}
        