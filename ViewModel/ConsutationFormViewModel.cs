using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PatientManagementSystem.Models;

namespace PatientManagementSystem.ViewModel
{
    public class ConsutationFormViewModel
    {
        public Consultation Consultation { get; set; }

        public Patient Patients { get; set; }
        public IEnumerable<Doctor> Doctor { get; set; }

        public IEnumerable<Diagnosis> Diagnosis { get; set; }
        public IEnumerable<ConsultationType> ConsultationType { get; set; }
   
    }
}