using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using PatientManagementSystem.Models;

namespace PatientManagementSystem.Dto
{
    public class PatientDto
    {
        public int PatientId { get; set; }


        [Required]
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
        public string IdNo { get; set; }

        [Required]
        [StringLength(1000)]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }

 //       [MedicalAidNameValidation]
        [StringLength(20)]
        public string MedicalAidName { get; set; }

//        [MedicalAidNoValidation]
        [StringLength(50)]
        public string MedicalAidNo { get; set; }

 //       [MedicalAidPlanValidation]
        [StringLength(50)]
        public string MedicalAidPlan { get; set; }
    }
}