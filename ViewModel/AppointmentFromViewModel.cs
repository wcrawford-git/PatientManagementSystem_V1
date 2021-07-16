using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PatientManagementSystem.Models;
using Microsoft.AspNet.Identity;

namespace PatientManagementSystem.ViewModel
{
    public class AppointmentFromViewModel
    {
        public Appointment Appointment { get; set; }
        public Patient Patient { get; set; }
        public IEnumerable<Doctor> Doctor { get; set; }
        public IEnumerable<DoctorType> DoctorType { get; set; }

        public Doctor DoctorEmail { get; set; }
    }
}