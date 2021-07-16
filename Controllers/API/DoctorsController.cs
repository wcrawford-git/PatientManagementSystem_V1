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
    public class DoctorsController : ApiController
    {
        private ApplicationDbContext _context;

        public DoctorsController()
        {
            _context = new ApplicationDbContext();
        }
        //GET/api/doctors
        public IHttpActionResult GetDoctors(string query = null)
        {
            var doctorsQuery = _context.Doctors
               .Include(c => c.DoctorType);

            if (!String.IsNullOrWhiteSpace(query))
                doctorsQuery = doctorsQuery.Where(c => c.Name.Contains(query));

            var doctorDtos = doctorsQuery
                .ToList()
                .Select(Mapper.Map<Doctor, DoctorDto>);

            return Ok(doctorDtos);
        }

        //Get/api/doctors/{id}
        public IHttpActionResult GetDoctor(int id)
        {
            var doctor = _context.Doctors.SingleOrDefault(p => p.DoctorId == id);

            if (doctor == null)
                return NotFound();

            return Ok(Mapper.Map<Doctor, DoctorDto>(doctor));

        }

        //Get/api/patients/{id}
       /* public IHttpActionResult GetAppointments(int id)
        {
            DateTime today = DateTime.Now.Date;
            var appointmentList = _context.Appointment
                 .Include(c => c.Patient)
                 .Include(c => c.Doctor)
                 .Where(c => c.DoctorId == id && c.DateTime >= today)
                 .OrderBy(c => c.DateTime)
                 .ThenBy(c => c.Time);

            //if (patient == null)
            //   return NotFound();

            return Ok(Mapper.Map<Patient, PatientDto>(patient));

        }*/

    

        //POST/api/doctors
        [HttpPost]
        public IHttpActionResult CreateDoctor(DoctorDto doctorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var doctor = Mapper.Map<DoctorDto, Doctor>(doctorDto);

            _context.Doctors.Add(doctor);
            _context.SaveChanges();

            doctorDto.DoctorId = doctor.DoctorId;

            return Created(new Uri(Request.RequestUri + "/" + doctor.DoctorId), doctorDto);
        }

        //PUT/api/doctors/{id}
        [HttpPut]
        public IHttpActionResult UpdateDoctor(int id, DoctorDto doctorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var doctorInDb = _context.Doctors.SingleOrDefault(d => d.DoctorId == id);

            if (doctorInDb == null)
                return NotFound();

            Mapper.Map(doctorDto, doctorInDb);

            _context.SaveChanges();

            return Ok();
        }
        //DELETE/api/doctors/{id}
        [HttpDelete]
        public IHttpActionResult DeleteDoctor(int id)
        {
            var doctorInDb = _context.Doctors.SingleOrDefault(d => d.DoctorId == id);

            if (doctorInDb == null)
                return NotFound();

            _context.Doctors.Remove(doctorInDb);
            _context.SaveChanges();

            return Ok();

        }
    }
}
