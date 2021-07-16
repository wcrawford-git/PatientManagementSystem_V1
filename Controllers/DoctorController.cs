using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PatientManagementSystem.Models;
using PatientManagementSystem.ViewModel;


namespace PatientManagementSystem.Controllers
{
    public class DoctorController : Controller
    {
        private ApplicationDbContext _context;

        public DoctorController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize(Roles = RoleName.Administrator)]
        public ActionResult New()
        {
            var doctorTypes = _context.DoctorType.ToList();
            var viewModel = new DoctorFormViewModel
            {
                Doctor = new Doctor(),
                DoctorTypes = doctorTypes,
             };
            return View("DoctorForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //Check Token
        public ActionResult Save(Doctor doctor)
        {
            //Validation
            if (!ModelState.IsValid)
            {
                var viewModel = new DoctorFormViewModel
                {
                    Doctor = doctor,
                    DoctorTypes = _context.DoctorType.ToList()
            };
                return View("DoctorForm", viewModel);

            }

            if (doctor.DoctorId == 0)
                _context.Doctors.Add(doctor);
            else
            {
                var existingDoctor = _context.Doctors.Single(p => p.DoctorTypeId == doctor.DoctorTypeId);

                existingDoctor.DoctorTypeId = doctor.DoctorTypeId;
                existingDoctor.Name = doctor.Name;
                existingDoctor.Surname = doctor.Surname;
                existingDoctor.PracticeNo = doctor.PracticeNo;
                existingDoctor.Address = doctor.Address;
                existingDoctor.Email = doctor.Email;
                existingDoctor.PhoneNo = doctor.PhoneNo;
            }
            _context.SaveChanges();


            return RedirectToAction("Index", "Doctor");
        }


        // GET: Doctor
        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.Administrator))
                return View("List");
            return View("ReadOnlyList");

        }
        public ActionResult Edit(int id)
        {
            var doctor = _context.Doctors.SingleOrDefault(p => p.DoctorId == id);

            if (doctor == null)
                return HttpNotFound();

            var viewModel = new DoctorFormViewModel
            {
                Doctor = doctor,
                DoctorTypes = _context.DoctorType.ToList()
            };
            return View("DoctorForm", viewModel);

        }

    }
}