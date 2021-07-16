using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PatientManagementSystem.Models;

namespace PatientManagementSystem.Controllers.API
{
    public class VaccinationTypeController : ApiController
    {
        private ApplicationDbContext _context;

        public VaccinationTypeController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<VaccinationType> GetVaccinationType()
        {

            return _context.VaccinationType.ToList();
        }
        [HttpDelete]
        public IHttpActionResult VaccinationType(int id)
        {
            var vaccinationTypeInDb = _context.VaccinationType.SingleOrDefault(p => p.VaccinationTypeId == id);

            if (vaccinationTypeInDb == null)
                return NotFound();

            _context.VaccinationType.Remove(vaccinationTypeInDb);
            _context.SaveChanges();

            return Ok();

        }
    }
}
