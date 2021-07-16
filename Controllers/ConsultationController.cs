using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PatientManagementSystem.Models;
using PatientManagementSystem.ViewModel;
using System.Data.Entity;


namespace PatientManagementSystem.Controllers
{
    public class ConsultationController : Controller
    {
        private ApplicationDbContext _context;

        public ConsultationController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New(int id)
        {
             var patient = _context.Patients.SingleOrDefault(p => p.PatientId == id);


              if (patient == null)
                  return HttpNotFound();
            var doctors = _context.Doctors.ToList();
            var diagnosis = _context.Diagnosis.ToList();
            var consultationType = _context.ConsultationType.ToList();

            var viewModel = new ConsutationFormViewModel
            {
                Patients = patient,
                Doctor = doctors,
                Diagnosis = diagnosis,
                ConsultationType = consultationType
            };
            return View("ConsultationForm", viewModel);
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ConsutationFormViewModel viewModel)
        {

            var consultation = new Consultation
            {
                PatientId = viewModel.Patients.PatientId,
                DoctorId = viewModel.Consultation.DoctorId,
                DiagnosisId = viewModel.Consultation.DiagnosisId,
                ConsultationTypeId = viewModel.Consultation.ConsultationTypeId,
                SymptomNotes = viewModel.Consultation.SymptomNotes,
                TreatmentNotes = viewModel.Consultation.TreatmentNotes,
                Amount = viewModel.Consultation.Amount,
                Date = DateTime.Now.ToString("dd-MM-yyyy").ToString()
            };

            _context.Consultations.Add(consultation);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");


        }
        [ChildActionOnly]
        public ActionResult ConsultationList(int id)
        {
            var consultationList = _context.Consultations
                 .Include(c => c.Patient)
                 .Include(c => c.Doctor)
                 .Include(c => c.Diagnosis)
                 .Include(c => c.ConsultationType)
                 .Where(c => c.PatientId == id);


            return PartialView("ConsultationList",consultationList);
        }
        // GET: Consultation
        public ActionResult Index()
        {
            return View();
        }
    }
}