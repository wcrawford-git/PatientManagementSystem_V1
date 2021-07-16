using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PatientManagementSystem.Models;

namespace PatientManagementSystem.Controllers.API
{
    public class ConsultationTypeController : ApiController
    {
        private ApplicationDbContext _context;

        public ConsultationTypeController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<ConsultationType> GetConsultationType()
        {

            return _context.ConsultationType.ToList();
        }
        //DELETE/api/consultationtype/{id}
        [HttpDelete]
        public IHttpActionResult DeleteConsultationType(int id)
        {
            var consultationTypeInDb = _context.ConsultationType.SingleOrDefault(p => p.ConsultationTypeId == id);

            if (consultationTypeInDb == null)
                return NotFound();

            _context.ConsultationType.Remove(consultationTypeInDb);
            _context.SaveChanges();

            return Ok();

        }
    }
}
