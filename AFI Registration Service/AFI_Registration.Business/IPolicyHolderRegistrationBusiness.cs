using AFI_Registration.Data.Entities;
using AFI_Registration.Common.Models;
using System.Threading.Tasks;

namespace AFI_Registration.Business
{
    public interface IPolicyHolderRegistrationBusiness
    {
        Task<PolicyHolderDetails> SavePolicyHolderDetails(PolicyHolderDetail policyHolderDetail);
    }
}
