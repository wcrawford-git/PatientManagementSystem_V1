using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PatientManagementSystem.Models;

namespace PatientManagementSystem.ViewModel
{
    public class VaccinationFormViewModel
    {
        public Vaccination Vaccinations { get; set; }
        public Patient Patients { get; set; }

        public IEnumerable<VaccinationType> VaccinationType { get; set; }
    }
}