namespace PatientManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataScripts : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                BEGIN
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0c2a7960-4bac-460a-85d5-382dbc8bbfc6', N'Administrator')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1d4a109e-4c17-4571-ab06-abe90901ef21', N'Doctor')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ae63e2f2-7f8b-4ab5-8a85-921621441571', N'User')  

                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'02f0e983-77e5-4809-ad27-ae3e9505c84d', N'test@pms.com', 0, N'AEY12s5B0jBOoAZiVuLqp7TQqaPkVbU6Bnbl8eKXcWAF5gB1XewBvfoxpynuZMHWMw==', N'9108f514-9e2e-4181-a323-1547da25ad47', NULL, 0, 0, NULL, 1, 0, N'test@pms.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0c94f1a0-ac0c-41b7-9f9f-57ce6b8ba5fd', N'guest@pms.com', 0, N'AIYsX5b/3noefOAtK30osfQQTmeutQbb+ftFia+soPT7ThaKHlDrlC5MzZ9rc6BSew==', N'0da1eadd-dc34-4f53-acb9-076b1d6d66d5', NULL, 0, 0, NULL, 1, 0, N'guest@pms.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3966ff96-c90c-406d-ac65-d78d6fe8bd74', N'admin@pms.com', 0, N'ANVEZgjT51rMblQKCRT2p56r8Y79oIK5YYqJ5XbM1xDCZWzZ9hPoStbSfCyz9An6Vg==', N'a0419cad-93f7-4069-88ce-91466284e16e', NULL, 0, 0, NULL, 1, 0, N'admin@pms.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4d58622b-5f58-40cb-b341-1668c976474d', N'doctor@pms.com', 0, N'AHgnqoQl/Nla01AwVM3iNraXmlir+zFEH7+bPwvH86gkEx8lLDPmylzV+3Qa1aRFHw==', N'c16ed420-00ba-45ff-b80c-bfcc9759bfc0', NULL, 0, 0, NULL, 1, 0, N'doctor@pms.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'760e9baa-a1a2-432a-a67a-6fb195fab233', N'lolly@dr.com', 0, N'AAfinuywQXRjF6WG09pTxClLeniYfJkeN+735ND8+n3xVwne2lRPJsV8dIFVhYGtnQ==', N'4c50bf0f-60e8-4a21-89cc-2d127d171c5d', NULL, 0, 0, NULL, 1, 0, N'lolly@dr.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9e7e70e0-2a6d-4195-a93e-fb89d8a44abd', N'administrator@pms.com', 0, N'ADDGW9pI4OtsKBmRKExsW+RtSzw3Hu3sSk/hI5dkVJesgT+1dORd3fPKBhrpmNmj8g==', N'9070bd60-8a19-432b-9ac5-8f1ae4c15ff3', NULL, 0, 0, NULL, 1, 0, N'administrator@pms.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ae4953a6-4a5a-42c1-b356-24b62c2129d7', N'wesley@pms.com', 0, N'AOhKp7Teo3B0O2E+8zlJTZCu9RbIXF0v7sIwnsBF94/DsQvP4HpcIwiJ+ZmLCUYHew==', N'41464eea-d33d-4074-9b19-8abe9e065c33', NULL, 0, 0, NULL, 1, 0, N'wesley@pms.com')

                SET IDENTITY_INSERT [dbo].[ConsultationTypes] ON
                INSERT INTO [dbo].[ConsultationTypes] ([ConsultationTypeId], [ConsultationDescription]) VALUES (1, N'Sick')
                INSERT INTO [dbo].[ConsultationTypes] ([ConsultationTypeId], [ConsultationDescription]) VALUES (2, N'Check Up')
                INSERT INTO [dbo].[ConsultationTypes] ([ConsultationTypeId], [ConsultationDescription]) VALUES (3, N'Vaccination')
                SET IDENTITY_INSERT [dbo].[ConsultationTypes] OFF


                SET IDENTITY_INSERT [dbo].[DoctorTypes] ON
                INSERT INTO [dbo].[DoctorTypes] ([DoctorTypeId], [DoctorTypeDescription]) VALUES (1, N'Physician')
                INSERT INTO [dbo].[DoctorTypes] ([DoctorTypeId], [DoctorTypeDescription]) VALUES (2, N'General Practioner')
                INSERT INTO [dbo].[DoctorTypes] ([DoctorTypeId], [DoctorTypeDescription]) VALUES (3, N'Dentist')
                INSERT INTO [dbo].[DoctorTypes] ([DoctorTypeId], [DoctorTypeDescription]) VALUES (4, N'Dermatologist')
                SET IDENTITY_INSERT [dbo].[DoctorTypes] OFF


                SET IDENTITY_INSERT [dbo].[PaymentMethods] ON
                INSERT INTO [dbo].[PaymentMethods] ([PaymentMethodId], [PaymentMethodDescription]) VALUES (1, N'Medical Aid')
                INSERT INTO [dbo].[PaymentMethods] ([PaymentMethodId], [PaymentMethodDescription]) VALUES (2, N'Cash')
                INSERT INTO [dbo].[PaymentMethods] ([PaymentMethodId], [PaymentMethodDescription]) VALUES (7, N'EFT')
                SET IDENTITY_INSERT [dbo].[PaymentMethods] OFF

                SET IDENTITY_INSERT [dbo].[VaccinationTypes] ON
                INSERT INTO [dbo].[VaccinationTypes] ([VaccinationTypeId], [VaccinationDescription]) VALUES (1, N'Covid-19')
                INSERT INTO [dbo].[VaccinationTypes] ([VaccinationTypeId], [VaccinationDescription]) VALUES (2, N'Measles')
                INSERT INTO [dbo].[VaccinationTypes] ([VaccinationTypeId], [VaccinationDescription]) VALUES (3, N'Chicken Pox')
                SET IDENTITY_INSERT [dbo].[VaccinationTypes] OFF
                END

            ");
        }
        
        public override void Down()
        {
        }
    }
}
