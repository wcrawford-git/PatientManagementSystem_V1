using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PatientManagementSystem.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public Patient Patient { get; set; }

        [Required]
        [Display(Name = "Patient Name")]
        public int PatientId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Payment Method")]
        public string PaymentMethod { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Payment Amount")]
        public int PaymentAmount { get; set; }

    }
}