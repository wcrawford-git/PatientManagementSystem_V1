using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PatientManagementSystem.Models
{
    public class PaymentMethod
    {
        public int PaymentMethodId { get; set; }

        [Required]
        [StringLength(50)]
        public string PaymentMethodDescription { get; set; }

        public static readonly byte Unknown = 0;
        public static readonly byte MedicalAid = 1;
        public static readonly byte Cash = 2;
    }
}