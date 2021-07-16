using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PatientManagementSystem.Dto;
using PatientManagementSystem.Models;

namespace PatientManagementSystem.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Patient, PatientDto>();
            Mapper.CreateMap<PatientDto, Patient>();
            Mapper.CreateMap<Doctor, DoctorDto>();
            Mapper.CreateMap<DoctorDto, Doctor>();
            Mapper.CreateMap<Appointment, DoctorDto>();
            Mapper.CreateMap<Appointment, PatientDto>();
            Mapper.CreateMap<DoctorDto, Appointment>();
            Mapper.CreateMap<PatientDto, Appointment>();

        }
    }
}