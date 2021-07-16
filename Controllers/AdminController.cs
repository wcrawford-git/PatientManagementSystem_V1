using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PatientManagementSystem.Models;
using PatientManagementSystem.ViewModel;

namespace PatientManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;

        public AdminController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public PartialViewResult AdminList(int id)
        {
            int list = id;

            if (list == 1)
                return PartialView("PaymentMethodList", _context.PaymentMethods.ToList());

            if (list == 2)
                return PartialView("DiagnosisList", _context.Diagnosis.ToList());

            if (list == 3)
                return PartialView("PaymentMethodList", _context.PaymentMethods.ToList());

            if (list == 4)
                return PartialView("DiagnosisList", _context.Diagnosis.ToList());

            if (list == 5)
                return PartialView("DiagnosisList", _context.Diagnosis.ToList());

            return PartialView("AdminList");
        }

        [ValidateAntiForgeryToken] //Check Token
        public ActionResult Save(int id, string description)
        {
            int list = id;
            if (list == 1)
                _context.PaymentMethods.Add(new PaymentMethod { PaymentMethodDescription = description });
                
            if (list == 2)
                _context.Diagnosis.Add(new Diagnosis { DiagnosisDescription = description });
            if (list == 3)
                _context.ConsultationType.Add(new ConsultationType {ConsultationDescription  = description });
            if (list == 4)
                _context.DoctorType.Add(new DoctorType { DoctorTypeDescription = description });
            if (list == 5)
                _context.VaccinationType.Add(new VaccinationType { VaccinationDescription = description });

            _context.SaveChanges();
            return PartialView("AdminForm");
        }
       /* [HttpDelete]
        public ActionResult Delete(int id, int obj)
        {
            if (id == 1)
            {
                var paymentMethodInDb = _context.PaymentMethods.SingleOrDefault(p => p.PaymentMethodId == obj);
                _context.PaymentMethods.Remove(paymentMethodInDb);
            }

            if (id == 2)
            {
                var diagnosisMethodInDb = _context.Diagnosis.SingleOrDefault(p => p.DiagnosisId == obj);
                _context.Diagnosis.Remove(diagnosisMethodInDb);
            }

            if (id == 3)
            {
                var consultationTypeInDb = _context.ConsultationType.SingleOrDefault(p => p.ConsultationTypeId == obj);
                _context.ConsultationType.Remove(consultationTypeInDb);
            }
            if (id == 4)
            {
                var doctorTypeInDb = _context.DoctorType.SingleOrDefault(p => p.DoctorTypeId == obj);
                _context.DoctorType.Remove(doctorTypeInDb);
            }
            if (id == 5)
            {
                var vaccinationTypeInDb = _context.VaccinationType.SingleOrDefault(p => p.VaccinationTypeId == obj);
                _context.VaccinationType.Remove(vaccinationTypeInDb);
            }


                _context.SaveChanges();

            return View("AdminForm");
        }*/

       /* public ActionResult DeleteDiagnosis(int id)
        {
            var diagnosisMethodInDb = _context.Diagnosis.SingleOrDefault(p => p.DiagnosisId == id);

            if (diagnosisMethodInDb == null)
                return HttpNotFound();

            _context.Diagnosis.Remove(diagnosisMethodInDb);
            _context.SaveChanges();

            return View("AdminForm");
        }
        public ActionResult DeleteConsultationType(int id)
        {
            var consultationTypeInDb = _context.ConsultationType.SingleOrDefault(p => p.ConsultationTypeId == id);

            if (consultationTypeInDb == null)
                return HttpNotFound();

            _context.ConsultationType.Remove(consultationTypeInDb);
            _context.SaveChanges();

            return View("AdminForm");
        }
        public ActionResult DeleteDoctorType(int id)
        {
            var doctorTypeInDb = _context.DoctorType.SingleOrDefault(p => p.DoctorTypeId == id);

            if (doctorTypeInDb == null)
                return HttpNotFound();

            _context.DoctorType.Remove(doctorTypeInDb);
            _context.SaveChanges();

            return View("AdminForm");
        }

        public ActionResult DeleteVaccinationType(int id)
        {
            var vaccinationTypeInDb = _context.VaccinationType.SingleOrDefault(p => p.VaccinationTypeId == id);

            if (vaccinationTypeInDb == null)
                return HttpNotFound();

            _context.VaccinationType.Remove(vaccinationTypeInDb);
            _context.SaveChanges();

            return View("AdminForm");
        }*/
        // GET: Admin
        public ActionResult Index()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "Payment Method", Value = "1" });
            items.Add(new SelectListItem { Text = "Diagnosis", Value = "2" });
            items.Add(new SelectListItem { Text = "Consultation Types", Value = "3" });
            items.Add(new SelectListItem { Text = "Doctor Types", Value = "4" });
            items.Add(new SelectListItem { Text = "Vaccination Types", Value = "5" });
            ViewBag.Admin = items;
            
            return View("AdminForm");
        }
    }
}