using AFI_Registration.Models;
using FluentValidation;
using System;

namespace AFI_Registration.Validator
{
    public class PolicyHolderDetailsValidator: AbstractValidator<PolicyHolderDetails>
    {
        /// <summary>
        /// Validator rules for PolicyHolderDetails
        /// </summary>
        public PolicyHolderDetailsValidator()
        {
            RuleFor(_ => _.FirstName)
                .NotEmpty()
                .WithMessage("Policy Holder First name is Mandatory.")
                .Length(3, 50)
                .WithMessage("Policy Holder First name should be between 3 to 50 characters.");

            RuleFor(_ => _.LastName)
                .NotEmpty()
                .WithMessage("Policy Holder Last name is Mandatory.")
                .Length(3, 50)
                .WithMessage("Policy Holder Last name should be between 3 to 50 characters.");

            RuleFor(_ => _.PolicyReferenceNumber)
                .NotEmpty()
                .WithMessage("Policy Reference Number is Mandatory.")
                .Matches(@"^[A-Z]{2}-\d{6}")
                .WithMessage("Policy Reference Number should have 2 alphabets in capital followed by 6 digits in AA-999999 format.");

            RuleFor(_ => _.DOB)
                .Must(BeValidAge)
                .WithMessage("Policy holder age should be 18 years or above.");
        }

        private bool BeValidAge(DateTime? date)
        {
            if (!date.HasValue || date.Value.Date.AddYears(18) <= DateTime.Now.Date)
                return true;
            else
                return false;
        }
    }
}
