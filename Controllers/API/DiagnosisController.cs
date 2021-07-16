using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PatientManagementSystem.Models;

namespace PatientManagementSystem.Controllers.API
{
    public class DiagnosisController : ApiController
    {
        private ApplicationDbContext _context;

        public DiagnosisController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<Diagnosis> GetDiagnosis()
        {

            return _context.Diagnosis.ToList();
        }

        //DELETE/api/diagnosis/{id}
        [HttpDelete]
        public IHttpActionResult DeleteDiagnosis(int id)
        {
            var diagnosisMethodInDb = _context.Diagnosis.SingleOrDefault(p => p.DiagnosisId == id);

            if (diagnosisMethodInDb == null)
                return NotFound();

            _context.Diagnosis.Remove(diagnosisMethodInDb);
            _context.SaveChanges();

            return Ok();

        }
    }
}
