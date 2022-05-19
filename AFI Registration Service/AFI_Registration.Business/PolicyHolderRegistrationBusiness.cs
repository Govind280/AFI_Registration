using AFI_Registration.Common.Models;
using AFI_Registration.Data.Data;
using AFI_Registration.Data.Entities;
using AFI_Registration.Common.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AFI_Registration.Business
{
    public class PolicyHolderRegistrationBusiness : IPolicyHolderRegistrationBusiness
    {
        private PolicyHolderDetailsContext _policyHolderDetailsContext;
        private ILogger<PolicyHolderRegistrationBusiness> _logger;

        public PolicyHolderRegistrationBusiness(
            PolicyHolderDetailsContext policyHolderDetailsContext,
            ILogger<PolicyHolderRegistrationBusiness> logger
            )
        {
            _policyHolderDetailsContext = policyHolderDetailsContext;
            _logger = logger;
        }

        public async Task<PolicyHolderDetails> SavePolicyHolderDetails(PolicyHolderDetail policyHolderDetail)
        {
            try
            {
                _logger.LogDebug($"Attempting to Save Policy holder details for Policy Reference : {policyHolderDetail.PolicyReferenceNumber}");

                PolicyHolderDetails policyHolderDetailsResponse = MapPolicyHolderDetails(policyHolderDetail);

                _policyHolderDetailsContext.PolicyHolderDetails.Add(policyHolderDetailsResponse);
                await _policyHolderDetailsContext.SaveChangesAsync();

                return policyHolderDetailsResponse;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Exception while saving policy holder details in PolicyHolderRegistrationBusiness.SavePolicyHolderDetails " +
                    $"for Policy Reference : {policyHolderDetail.PolicyReferenceNumber}");

                throw;
            }
        }

        private PolicyHolderDetails MapPolicyHolderDetails(PolicyHolderDetail policyHolderDetail) =>
            new()
            {
                FirstName = policyHolderDetail.FirstName,
                LastName = policyHolderDetail.LastName,
                PolicyReferenceNumber = policyHolderDetail.PolicyReferenceNumber,
                DOB = policyHolderDetail.DOB
            };
    }
}
