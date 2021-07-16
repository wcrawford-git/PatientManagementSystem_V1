using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PatientManagementSystem.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }

        public DoctorType DoctorType { get; set; }

        [Required]
        [Display(Name = "Specialization")]
        public int DoctorTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Practice Number")]
        public string PracticeNo { get; set; }

        [Required]
        [StringLength(1000)]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^0([0-9]{9})$", ErrorMessage = "Invalid Telephone Number.")]
        [StringLength(50)]
        [Display(Name = "Telephone Number")]
        public string PhoneNo { get; set; }


    }
}