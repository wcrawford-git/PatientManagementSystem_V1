using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PatientManagementSystem.Models
{
    public class MedicalAidNameValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var patient = (Patient)validationContext.ObjectInstance;
            if (patient.PaymentMethodId == PaymentMethod.Unknown ||
                patient.PaymentMethodId == PaymentMethod.Cash)
                return ValidationResult.Success;



            if (patient.MedicalAidName == null)
                return new ValidationResult("Medical Aid Name is required");
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}