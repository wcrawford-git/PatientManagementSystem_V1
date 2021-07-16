using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PatientManagementSystem.Models;

namespace PatientManagementSystem.ViewModel
{
    public class PaymentFormViewModel
    {
        public int TotalOutstanding { get; set; }

        public int TotalPaid { get; set; }

        public int Balance { get; set; }
        public Payment Payment { get; set; }

        public Patient Patient { get; set; }
        public IEnumerable<Consultation> Consultation { get; set; }
        public IEnumerable<PaymentMethod> PaymentMethod { get; set; }
    }
}