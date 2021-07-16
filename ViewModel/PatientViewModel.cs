using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PatientManagementSystem.Models;

namespace PatientManagementSystem.ViewModel
{
    public class PatientViewModel
    {
        public List<Patient> Patients { get; set; }
        public PaymentMethod PaymentMethod { get; set; }


    }
}