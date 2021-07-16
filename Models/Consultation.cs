using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PatientManagementSystem.Models
{
    public class Consultation
    {
        public int ConsultationId { get; set; }

        public Patient Patient { get; set; }
        [Required]
        [Display(Name = "Patient Name")]
        public int PatientId { get; set; }


        public Doctor Doctor { get; set; }
        [Required]
        [Display(Name = "Doctor Name")]
        public int DoctorId { get; set; }

        //public Appointment Appointment { get; set; }
        
       // [Display(Name = "Appointment")]
       // public int AppointmentId { get; set; }
        public Diagnosis Diagnosis { get; set; }
        [Required]
        [Display(Name = "Diagnosis")]
        public int DiagnosisId { get; set; }

        public ConsultationType ConsultationType { get; set; }
        [Required]
        [Display(Name = "Consultation Type")]
        public int ConsultationTypeId { get; set; }

        [Required]
        [StringLength(1000)]
        [Display(Name = "Symptom Notes")]
        public string SymptomNotes { get; set; }

        [Required]
        [StringLength(1000)]
        [Display(Name = "Treatment Notes")]
        public string TreatmentNotes { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public string Date { get; set; }

    }
}