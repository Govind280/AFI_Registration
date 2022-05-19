using AFI_Registration.Business;
using AFI_Registration.Common.Models;
using AFI_Registration.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AFI_Registration.Controllers
{
    /// <summary>
    /// Registration Controller contains all endpoints related to Adding or updating policy holder details
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private ILogger<RegistrationController> _logger;
        private IPolicyHolderRegistrationBusiness _policyHolderRegistrationBusiness;

        /// <summary>
        /// Constructor for <see cref="RegistrationController"/>
        /// </summary>
        /// <param name="logger"><see cref="ILogger<RegistrationController>"/></param>
        /// <param name="policyHolderRegistrationBusiness"><see cref="IPolicyHolderRegistrationBusiness"/></param>
        public RegistrationController(ILogger<RegistrationController> logger, IPolicyHolderRegistrationBusiness policyHolderRegistrationBusiness)
        {
            _logger = logger;
            _policyHolderRegistrationBusiness = policyHolderRegistrationBusiness;
        }

        /// <summary>
        /// Register Policy holder
        /// </summary>
        /// <param name="policyHolderDetail"><see cref="PolicyHolderDetail"/></param>
        /// <returns><see cref="Task<PolicyHolderDetails>"/></returns>
        [HttpPost]
        public async Task<IActionResult> RegisterPolicyHolder([FromBody] PolicyHolderDetail policyHolderDetail)
        {
            try
            {
                PolicyHolderDetails policyHolderDetails = await _policyHolderRegistrationBusiness.SavePolicyHolderDetails(policyHolderDetail);

                if (policyHolderDetails.CustomerID > 0)
                {
                    return Ok(policyHolderDetails.CustomerID);
                }

                return BadRequest("Registration failed. Please contact Administrator.");
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Unable to Register Policy holder for Policy Reference {policyHolderDetail.PolicyReferenceNumber}");
                throw;
            }
        }
    }
}
