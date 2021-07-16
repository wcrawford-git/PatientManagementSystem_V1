using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PatientManagementSystem.Models;
using PatientManagementSystem.Dto;
using AutoMapper;
using System.Data.Entity;


namespace PatientManagementSystem.Controllers.API
{
    public class PatientsController : ApiController
    {
        private ApplicationDbContext _context;

        public PatientsController()
        {
            _context = new ApplicationDbContext();
        }
        //GET/api/patients
        public IHttpActionResult GetPatients(string query = null)
        {
            var patientsQuery = _context.Patients
               .Include(c => c.PaymentMethod);

            if (!String.IsNullOrWhiteSpace(query))
                patientsQuery = patientsQuery.Where(c => c.Name.Contains(query));

            var customerDtos = patientsQuery
                .ToList()
                .Select(Mapper.Map<Patient, PatientDto>);

            return Ok(customerDtos);
        }



        //Get/api/patients/{id}
        public IHttpActionResult GetPatientDoctor(int id)
        {
            var patient = _context.Patients.SingleOrDefault(p => p.PatientId == id);

            if (patient == null)
                return NotFound();

            return Ok(Mapper.Map<Patient, PatientDto>(patient));

        }



        //POST/api/patients
        [HttpPost]
        public IHttpActionResult CreatePatient(PatientDto patientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var patient = Mapper.Map<PatientDto, Patient>(patientDto);

            _context.Patients.Add(patient);
            _context.SaveChanges();

            patientDto.PatientId = patient.PatientId;

            return Created(new Uri(Request.RequestUri + "/" + patient.PatientId),patientDto);
        }

        //PUT/api/patients/{id}
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, PatientDto patientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var patientInDb = _context.Patients.SingleOrDefault(p => p.PatientId == id);

            if (patientInDb == null)
                return NotFound();

            Mapper.Map(patientDto, patientInDb);
           
            _context.SaveChanges();

            return Ok();
        }

        //DELETE/api/patients/{id}
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var patientInDb = _context.Patients.SingleOrDefault(p => p.PatientId == id);

            if (patientInDb == null)
                return NotFound();

            _context.Patients.Remove(patientInDb);
            _context.SaveChanges();

            return Ok();

        }
    }
}
