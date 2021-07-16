using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PatientManagementSystem.Models
{
    public class Patient
    {
        public int PatientId { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        [Required]
        [Display(Name = "Payment Method")]
        public int PaymentMethodId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        //public Gender Sex { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Id Number")]
        public string IdNo { get; set; }

        [Required]
        [StringLength(1000)]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
       // [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", ErrorMessage = "Invalid Email Address.")]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^0([0-9]{9})$", ErrorMessage = "Invalid Telephone Number.")]
        [StringLength(50)]
        [Display(Name = "Cell Number")]
        public string Phone { get; set; }

        [MedicalAidNameValidation]
        [StringLength(20)]
        [Display(Name = "Medical Aid Name")]
        public string MedicalAidName { get; set; }

        [MedicalAidNoValidation]
        [StringLength(50)]
        [Display(Name = "Medical Aid Number")]
        public string MedicalAidNo { get; set; }

        [MedicalAidPlanValidation]
        [StringLength(50)]
        [Display(Name = "Medical Aid Plan")]
        public string MedicalAidPlan { get; set; }
    }
}