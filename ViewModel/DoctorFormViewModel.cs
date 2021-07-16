using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PatientManagementSystem.Models;

namespace PatientManagementSystem.ViewModel
{
    public class DoctorFormViewModel
    {
        public IEnumerable<DoctorType> DoctorTypes { get; set; }

        public Doctor Doctor { get; set; }

        public string Title
        {
            get
            {
                if (Doctor != null && Doctor.DoctorId != 0)
                    return "Edit Doctor";

                return "New Doctor";
            }
        }
    }
}