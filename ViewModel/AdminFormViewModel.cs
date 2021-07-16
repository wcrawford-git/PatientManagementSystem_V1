using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PatientManagementSystem.Models;

namespace PatientManagementSystem.ViewModel
{
    public class AdminFormViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public PaymentMethod Paymetmethod { get; set; }
        public Diagnosis Diagnosis { get; set; }

     
    }
}