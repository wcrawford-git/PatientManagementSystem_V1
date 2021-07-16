using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using PatientManagementSystem.Models;
using PatientManagementSystem.ViewModel;

namespace PatientManagementSystem.Controllers.API
{
    public class PaymentMethodController : ApiController
    {
        private ApplicationDbContext _context;

        public PaymentMethodController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<PaymentMethod> GetPaymentMethods()
        {

            return _context.PaymentMethods.ToList();
        }

        //DELETE/api/paymentmethod/{id}
        [HttpDelete]
        public IHttpActionResult DeletePaymentMethod(int id)
        {
            var paymentMethodInDb = _context.PaymentMethods.SingleOrDefault(p => p.PaymentMethodId == id); 

            if (paymentMethodInDb == null)
                return NotFound();

            _context.PaymentMethods.Remove(paymentMethodInDb);
            _context.SaveChanges();

            return Ok();

        }
    }
}
