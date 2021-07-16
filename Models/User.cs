using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PatientManagementSystem.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        [StringLength(20)]
        public string IdNumber { get; set; }
        [Required]
        [StringLength(50)]
        public string UserType { get; set; }
    }
}