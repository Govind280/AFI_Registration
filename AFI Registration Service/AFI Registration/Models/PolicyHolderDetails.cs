using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFI_Registration.Models
{
    public class PolicyHolderDetails
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PolicyReferenceNumber { get; set; }

        public DateTime? DOB { get; set; }  
    }
}
