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
    public class PaymentController : Controller
    {
        private ApplicationDbContext _context;

        public PaymentController()
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

            var consultations = _context.Consultations.ToList();

            var totalOutstanding = _context.Consultations
                .Where(p => p.PatientId == id)
                .Select(p => p.Amount)
                .DefaultIfEmpty(0)
                .Sum();

            var totalPaid = _context.Payment
               .Where(p => p.PatientId == id)
               .Select(p => p.PaymentAmount)
               .DefaultIfEmpty(0)
               .Sum();

            var balance = totalOutstanding - totalPaid;

            var viewModel = new PaymentFormViewModel
            {
                Patient = patient,
                Consultation = consultations,
                TotalOutstanding = totalOutstanding,
                TotalPaid = totalPaid,
                Balance = balance
            };
            return View("PaymentForm", viewModel);
        }

        [ValidateAntiForgeryToken] //Check Token
        public ActionResult Save(PaymentFormViewModel viewModel)
        {

            var payment = new Payment
            {
                PatientId = viewModel.Patient.PatientId,
                PaymentMethod = viewModel.Payment.PaymentMethod,
                Date = viewModel.Payment.Date,
                PaymentAmount = viewModel.Payment.PaymentAmount
            };

            _context.Payment.Add(payment);
            _context.SaveChanges();

            return RedirectToAction("Index", "Patient");
        }
        public ActionResult PaymentList(int id)
        {
            var paymentList = _context.Payment
                 .Include(c => c.Patient)
                 .Where(c => c.PatientId == id);


            return PartialView("PaymentList", paymentList);
        }

        public ActionResult InvoiceList(int id)
        {
            var invoiceList = _context.Consultations
                 .Include(c => c.Patient)
                 .Include(c => c.Doctor)
                 .Where(c => c.PatientId == id);


            return PartialView("InvoiceList", invoiceList);
        }


        // GET: Payment
        public ActionResult Index()
        {
            return View();
        }
    }
}