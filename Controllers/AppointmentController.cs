using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PatientManagementSystem.Models;
using PatientManagementSystem.ViewModel;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace PatientManagementSystem.Controllers
{
    public class AppointmentController : Controller
    {
        private ApplicationDbContext _context;

        public AppointmentController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New(int id)
        {
            var patient = _context.Patients.Single(p => p.PatientId == id);


            if (patient == null)
                return HttpNotFound();
            var doctors = _context.Doctors;
           
            var viewModel = new AppointmentFromViewModel
            {
                Patient = patient,
                Doctor = doctors,
            };
            return View("AppointmentForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(AppointmentFromViewModel viewModel)
        {

            var appointment = new Appointment
            {
                PatientId = viewModel.Patient.PatientId,
                DoctorId = viewModel.Appointment.DoctorId,
               DateTime = viewModel.Appointment.DateTime,
               Time = viewModel.Appointment.Time
            };

            _context.Appointment.Add(appointment);
            _context.SaveChanges();

            return RedirectToAction("Index", "Patient");


        }
       // [ChildActionOnly]
        public PartialViewResult AppointmentList(int id)
        {
            DateTime today = DateTime.Now.Date;
            var appointmentList = _context.Appointment
                 .Include(c => c.Patient)
                 .Include(c => c.Doctor)
                 .Where(c => c.DoctorId == id && c.DateTime >= today)
                 .OrderBy(c => c.DateTime)
                 .ThenBy(c => c.Time);


            return PartialView("AppointmentList", appointmentList);
        }

        public PartialViewResult AppointmentList()
        {
            DateTime today = DateTime.Now.Date;
            var appointmentList = _context.Appointment
                 .Include(c => c.Patient)
                 .Include(c => c.Doctor)
                 .Where(c => c.Doctor.Email == User.Identity.GetUserName() && c.DateTime >= today)
                 .OrderBy(c => c.DateTime)
                 .ThenBy(c => c.Time);


            return PartialView("AppointmentList", appointmentList);
        }

        public ViewResult DoctorAppointmentList()
        {
            IEnumerable<Doctor> doctors = _context.Doctors;
            var viewModel = new AppointmentFromViewModel
            {
                Doctor = doctors,
            };


            return View("DoctorAppointmentList", viewModel);
        }

        public ViewResult DoctorAppointmentListAdmin()
        {
            IEnumerable<Doctor> doctors = _context.Doctors;
            var viewModel = new AppointmentFromViewModel
            {
                Doctor = doctors,
            };


            return View("DoctorAppointmentListAdmin", viewModel);
        }
        // GET: Appointment
        public ActionResult Index()
        {
            return View();
        }
    }
}