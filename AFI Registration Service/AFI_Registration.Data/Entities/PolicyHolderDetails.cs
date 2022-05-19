using System;
using System.ComponentModel.DataAnnotations;

namespace AFI_Registration.Data.Entities
{
    public class PolicyHolderDetails
    {
        [Key]

        public int PolicyHolderDetailId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PolicyReferenceNumber { get; set; }

        public DateTime? DOB { get; set; }

        public int CustomerID { get; set; }
    }
}
