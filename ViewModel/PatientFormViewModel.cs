using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PatientManagementSystem.Models;

namespace PatientManagementSystem.ViewModel
{
    public class PatientFormViewModel
    {
        public IEnumerable<PaymentMethod> PaymentMethods { get; set; }
        public Patient Patient { get; set; }

        public string Title
        {
            get
            {
                if (Patient != null && Patient.PatientId != 0)
                    return "Edit Patient";

                return "New Patient";
            }
        }
    }

   

}