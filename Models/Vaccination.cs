using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PatientManagementSystem.Models
{
    public class Vaccination
    {
        public int VaccinationId { get; set; }
        public Patient Patient { get; set; }

        [Required]
        [Display(Name = "Patient Name")]
        public int PatientId { get; set; }

        public VaccinationType VaccinationType { get; set; }

        [Required]
        [Display(Name = "Vaccination Type")]
        public int VaccinationTypeId { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        [StringLength(100)]
        public string Site { get; set; }

    }
}