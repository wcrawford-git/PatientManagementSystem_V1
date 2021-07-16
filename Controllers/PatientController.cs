using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PatientManagementSystem.Models;
using PatientManagementSystem.ViewModel;

namespace PatientManagementSystem.Controllers
{
    public class PatientController : Controller
    {

      /*  public ActionResult Details()
        {
            var diagnosis = new Diagnosis() { DiagnosisDescription = "Healthy" };
            var patients = new List<Patient>
            {
                new Patient { Name = "Wesley"},
                new Patient { Name = "Lolly"}
            };

            var viewModel = new PatientViewModel
            {
                Diagnosis = diagnosis,
                Patients = patients

            };

            return View(viewModel);
        }*/

        private ApplicationDbContext _context;

        public PatientController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var paymentMethods = _context.PaymentMethods.ToList();
            var viewModel = new PatientFormViewModel
            {
                Patient = new Patient(),
                PaymentMethods = paymentMethods
            };
            return View("PatientForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //Check Token
        public ActionResult Save(Patient patient)
        {
            //Validation
            if (!ModelState.IsValid)
            {
                var viewModel = new PatientFormViewModel
                {
                    Patient = patient,
                    PaymentMethods = _context.PaymentMethods.ToList()
                };
                return View("PatientForm", viewModel);

            }

            if (patient.PatientId == 0)
                _context.Patients.Add(patient);
            else
            {
                var existingPatient = _context.Patients.Single(p => p.PatientId == patient.PatientId);

                existingPatient.PaymentMethodId = patient.PaymentMethodId;
                existingPatient.Name = patient.Name;
                existingPatient.Surname = patient.Surname;
                existingPatient.IdNo = patient.IdNo;
                existingPatient.Address = patient.Address;
                existingPatient.Email = patient.Email;
                existingPatient.Phone = patient.Phone;
                existingPatient.MedicalAidName = patient.MedicalAidName;
                existingPatient.MedicalAidNo = patient.MedicalAidNo;
                existingPatient.MedicalAidPlan = patient.MedicalAidPlan;


            }
            _context.SaveChanges();

           
            return RedirectToAction("Index", "Patient");
        }

        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.Administrator))
                return View("List");
            return View("UserList");
                    
        }

       /* [HttpPost]
        public ActionResult Index(string option, string search)
        {

            //var patients = _context.Patients.ToList();

            //return View(patients);
        
            if (option == "Name")
            {
                //Index action method will return a view with a student records based on what a user specify the value in textbox  
                //return View(db.Students.Where(x = > x.Subjects == search || search == null).ToList());
                return View("Index", _context.Patients.Where(p => p.Name == search).ToList());
    
            }
            else if (option == "Surname")
            {
                //return View(db.Students.Where(x = > x.Gender == search || search == null).ToList());
                return View(_context.Patients.Where(p => p.Surname == search).ToList());
            }
            else
            {
                return View(_context.Patients.Where(p => p.IdNo == search).ToList());
            }

        }*/

        public ActionResult Details(int id)
        {
            //var patient = new Patient() { Name = "Wesley" };
            var patient = _context.Patients.SingleOrDefault(p => p.PatientId == id);

            if (patient == null)
                return HttpNotFound();

            return View(patient);

        }

        public ActionResult Edit(int id)
        {
            var patient = _context.Patients.SingleOrDefault(p => p.PatientId == id);

            if (patient == null)
                return HttpNotFound();

            var viewModel = new PatientFormViewModel
            {
                Patient = patient,
                PaymentMethods = _context.PaymentMethods.ToList()
            };
            return View("PatientForm", viewModel);

        }

    }

}