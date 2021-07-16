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
    public class VaccinationController : Controller
    {
        private ApplicationDbContext _context;

        public VaccinationController()
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
            var vaccinationType = _context.VaccinationType.ToList();

            var viewModel = new VaccinationFormViewModel
            {
                Patients = patient,
                VaccinationType = vaccinationType.ToList()
            };
            return View("VaccinationForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(VaccinationFormViewModel viewModel)
        {

            var vaccination = new Vaccination
            {
                PatientId = viewModel.Patients.PatientId,
                VaccinationTypeId = viewModel.Vaccinations.VaccinationTypeId,
                Date = DateTime.Now.ToString("dd-MM-yyyy").ToString(),
                Site = viewModel.Vaccinations.Site
            };

            _context.Vaccination.Add(vaccination);
            _context.SaveChanges();

            return RedirectToAction("Index", "Patient");


        }
        [ChildActionOnly]
        public ActionResult VaccinationList(int id)
        {
            var vaccinationList = _context.Vaccination
                 .Include(c => c.Patient)
                 .Include(c => c.VaccinationType)
                 .Where(c => c.PatientId == id);


            return PartialView("VaccinationList", vaccinationList);
        }
        // GET: Vaccination
        public ActionResult Index()
        {
            return View();
        }
    }
}