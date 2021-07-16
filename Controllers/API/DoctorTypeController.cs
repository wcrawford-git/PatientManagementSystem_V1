using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PatientManagementSystem.Models;

namespace PatientManagementSystem.Controllers.API
{
    public class DoctorTypeController : ApiController
    {
        private ApplicationDbContext _context;

        public DoctorTypeController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<DoctorType> GetDoctorType()
        {

            return _context.DoctorType.ToList();
        }
        //DELETE/api/doctortype/{id}
        [HttpDelete]
        public IHttpActionResult DeleteDoctorType(int id)
        {
            var doctorTypeInDb = _context.DoctorType.SingleOrDefault(p => p.DoctorTypeId == id);

            if (doctorTypeInDb == null)
                return NotFound();

            _context.DoctorType.Remove(doctorTypeInDb);
            _context.SaveChanges();

            return Ok();

        }
    }
}
