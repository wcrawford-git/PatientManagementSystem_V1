namespace PatientManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataScripts2 : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                BEGIN
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9e7e70e0-2a6d-4195-a93e-fb89d8a44abd', N'0c2a7960-4bac-460a-85d5-382dbc8bbfc6')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4d58622b-5f58-40cb-b341-1668c976474d', N'1d4a109e-4c17-4571-ab06-abe90901ef21')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'760e9baa-a1a2-432a-a67a-6fb195fab233', N'1d4a109e-4c17-4571-ab06-abe90901ef21')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'02f0e983-77e5-4809-ad27-ae3e9505c84d', N'ae63e2f2-7f8b-4ab5-8a85-921621441571')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ae4953a6-4a5a-42c1-b356-24b62c2129d7', N'ae63e2f2-7f8b-4ab5-8a85-921621441571')
 
 
                SET IDENTITY_INSERT [dbo].[Diagnosis] ON
                INSERT INTO [dbo].[Diagnosis] ([DiagnosisId], [DiagnosisDescription]) VALUES (1, N'Allergies')
                INSERT INTO [dbo].[Diagnosis] ([DiagnosisId], [DiagnosisDescription]) VALUES (2, N'Gastro Reflux')
                INSERT INTO [dbo].[Diagnosis] ([DiagnosisId], [DiagnosisDescription]) VALUES (3, N'Hypertention')
                INSERT INTO [dbo].[Diagnosis] ([DiagnosisId], [DiagnosisDescription]) VALUES (4, N'Other')
                SET IDENTITY_INSERT [dbo].[Diagnosis] OFF
 
                SET IDENTITY_INSERT [dbo].[Doctors] ON
                INSERT INTO [dbo].[Doctors] ([DoctorId], [DoctorTypeId], [Name], [Surname], [address], [email], [PracticeNo], [PhoneNo]) VALUES (1, 1, N'Wesley', N'Crawford', N'340 Best Street, Florida', N'doctor@pms.com', N'123456', N'0834445555')
                INSERT INTO [dbo].[Doctors] ([DoctorId], [DoctorTypeId], [Name], [Surname], [address], [email], [PracticeNo], [PhoneNo]) VALUES (3, 4, N'Dr Lolly', N'Crawford', N'60 Esperanza Street, Florida', N'lolly@dr.com', N'1224356', N'0814335806')
                INSERT INTO [dbo].[Doctors] ([DoctorId], [DoctorTypeId], [Name], [Surname], [address], [email], [PracticeNo], [PhoneNo]) VALUES (4, 2, N'Dr Aadiel', N'Bhodhania', N'Republic Road
                340', N'abc@abc.com', N'234634634', N'0113334444')
                SET IDENTITY_INSERT [dbo].[Doctors] OFF
 
                SET IDENTITY_INSERT [dbo].[Patients] ON
                INSERT INTO [dbo].[Patients] ([PatientId], [PaymentMethodId], [Name], [IdNo], [Address], [Email], [Phone], [MedicalAidName], [MedicalAidNo], [MedicalAidPlan], [Surname]) VALUES (11, 2, N'Illeanna', N'12351', N'1 Jane Ave, Florida, 1709', N'Illeanna@a.com', N'0832223375', NULL, NULL, NULL, N'Crawford')
                INSERT INTO [dbo].[Patients] ([PatientId], [PaymentMethodId], [Name], [IdNo], [Address], [Email], [Phone], [MedicalAidName], [MedicalAidNo], [MedicalAidPlan], [Surname]) VALUES (12, 2, N'laylynn', N'12352', N'1 Jane Ave, Florida, 1709', N'Illeanna@a.com', N'0832233375', NULL, NULL, NULL, N'Crawford')
                INSERT INTO [dbo].[Patients] ([PatientId], [PaymentMethodId], [Name], [IdNo], [Address], [Email], [Phone], [MedicalAidName], [MedicalAidNo], [MedicalAidPlan], [Surname]) VALUES (13, 2, N'Wesley', N'12355', N'1 Wesley Ave, Florida, 1709', N'Wesleyd@a.com', N'0832233475', NULL, NULL, NULL, N'Crawford')
                INSERT INTO [dbo].[Patients] ([PatientId], [PaymentMethodId], [Name], [IdNo], [Address], [Email], [Phone], [MedicalAidName], [MedicalAidNo], [MedicalAidPlan], [Surname]) VALUES (19, 2, N'Lolly', N'8672140925', N'Republic Road
                340', N'lolly@a.com', N'082334565', NULL, NULL, NULL, N'Crawford')
                SET IDENTITY_INSERT [dbo].[Patients] OFF
                END
            ");
        }
        
        public override void Down()
        {
        }
    }
}
