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
    public class AppointmentController : ApiController
    {
        private ApplicationDbContext _context;

        public AppointmentController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<Appointment> GetAppointments(int id)
        {
            DateTime today = DateTime.Now.Date;
            var appointmentList = _context.Appointment
                 .Include(c => c.Patient)
                 .Where(c => c.DoctorId == id && c.DateTime >= today)
                 .OrderBy(c => c.DateTime)
                 .ThenBy(c => c.Time);


            return appointmentList;
        }
       [HttpGet]
        public IEnumerable<Appointment> GetAppointments(string email)
        {
            var doctorEmail = _context.Doctors.SingleOrDefault(d => d.Email == email);
                              

            DateTime today = DateTime.Now.Date;
            var appointmentList = _context.Appointment
                 .Include(c => c.Patient)
                 .Where(c => c.DoctorId == doctorEmail.DoctorId && c.DateTime >= today)
                 .OrderBy(c => c.DateTime)
                 .ThenBy(c => c.Time);


            return appointmentList;
        }

    }
}
