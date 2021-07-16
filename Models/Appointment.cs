using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PatientManagementSystem.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime DateTime { get; set; }

        [Required]
        public string Time { get; set; }

        public Doctor Doctor { get; set; }
        [Required]
        [Display(Name = "Doctor")]
        public int DoctorId { get; set; }

        public Patient Patient { get; set; }
        [Required]
        [Display(Name = "Patient Name")]
        public int PatientId { get; set; }
    }
}