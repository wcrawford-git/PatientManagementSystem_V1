using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace PatientManagementSystem.Dto
{
    public class AppointmentDto
    {
        public int AppointmentId { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public string Time { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public int PatientId { get; set; }
    }
}