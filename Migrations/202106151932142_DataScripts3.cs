namespace PatientManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataScripts3 : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                BEGIN
                SET IDENTITY_INSERT [dbo].[Appointments] ON
                INSERT INTO [dbo].[Appointments] ([AppointmentId], [DateTime], [DoctorId], [PatientId], [Time]) VALUES (5, N'2021-06-09 00:00:00', 3, 11, N'21:00')
                INSERT INTO [dbo].[Appointments] ([AppointmentId], [DateTime], [DoctorId], [PatientId], [Time]) VALUES (6, N'2021-06-09 00:00:00', 3, 12, N'10:30')
                INSERT INTO [dbo].[Appointments] ([AppointmentId], [DateTime], [DoctorId], [PatientId], [Time]) VALUES (7, N'2021-06-11 00:00:00', 3, 11, N'11:00')
                INSERT INTO [dbo].[Appointments] ([AppointmentId], [DateTime], [DoctorId], [PatientId], [Time]) VALUES (8, N'2021-06-11 00:00:00', 3, 11, N'14:00')
                INSERT INTO [dbo].[Appointments] ([AppointmentId], [DateTime], [DoctorId], [PatientId], [Time]) VALUES (9, N'2021-06-14 00:00:00', 1, 19, N'10:00')
                INSERT INTO [dbo].[Appointments] ([AppointmentId], [DateTime], [DoctorId], [PatientId], [Time]) VALUES (10, N'2021-06-14 00:00:00', 1, 12, N'11:00')
                INSERT INTO [dbo].[Appointments] ([AppointmentId], [DateTime], [DoctorId], [PatientId], [Time]) VALUES (11, N'2021-06-16 00:00:00', 3, 12, N'10:00')
                SET IDENTITY_INSERT [dbo].[Appointments] OFF

                SET IDENTITY_INSERT [dbo].[Consultations] ON
                INSERT INTO [dbo].[Consultations] ([ConsultationId], [PatientId], [DoctorId], [DiagnosisId], [ConsultationTypeId], [SymptomNotes], [TreatmentNotes], [Amount], [Date]) VALUES (11, 11, 1, 1, 1, N'dad', N'asds', 300, N'06-06-2021')
                INSERT INTO [dbo].[Consultations] ([ConsultationId], [PatientId], [DoctorId], [DiagnosisId], [ConsultationTypeId], [SymptomNotes], [TreatmentNotes], [Amount], [Date]) VALUES (13, 13, 1, 1, 1, N'Test', N'Test', 300, N'07-06-2021')
                INSERT INTO [dbo].[Consultations] ([ConsultationId], [PatientId], [DoctorId], [DiagnosisId], [ConsultationTypeId], [SymptomNotes], [TreatmentNotes], [Amount], [Date]) VALUES (14, 12, 1, 3, 2, N'Test Symptom', N'Test Treatment', 500, N'05-06-2021')
                INSERT INTO [dbo].[Consultations] ([ConsultationId], [PatientId], [DoctorId], [DiagnosisId], [ConsultationTypeId], [SymptomNotes], [TreatmentNotes], [Amount], [Date]) VALUES (16, 19, 1, 2, 1, N'Test ', N'Test', 300, N'12-06-2021')
                SET IDENTITY_INSERT [dbo].[Consultations] OFF
 
                SET IDENTITY_INSERT [dbo].[Payments] ON
                INSERT INTO [dbo].[Payments] ([PaymentId], [PaymentMethod], [Date], [PaymentAmount], [PatientId]) VALUES (1, N'Cash', N'2021-06-10 00:00:00', 200, 11)
                INSERT INTO [dbo].[Payments] ([PaymentId], [PaymentMethod], [Date], [PaymentAmount], [PatientId]) VALUES (2, N'Cash', N'2021-06-12 00:00:00', 200, 19)
                SET IDENTITY_INSERT [dbo].[Payments] OFF
 
                SET IDENTITY_INSERT [dbo].[Vaccinations] ON
                INSERT INTO [dbo].[Vaccinations] ([VaccinationId], [PatientId], [VaccinationTypeId], [date], [Site]) VALUES (4, 11, 2, N'07-06-2021', N'Flora Clinic')
                INSERT INTO [dbo].[Vaccinations] ([VaccinationId], [PatientId], [VaccinationTypeId], [date], [Site]) VALUES (5, 19, 1, N'12-06-2021', N'Flora Clinic')
                SET IDENTITY_INSERT [dbo].[Vaccinations] OFF
                END
            ");
        }
        
        public override void Down()
        {
        }
    }
}
