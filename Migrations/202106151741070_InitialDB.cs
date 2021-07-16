namespace PatientManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
          
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        AppointmentId = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Time = c.String(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AppointmentId)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorId = c.Int(nullable: false, identity: true),
                        DoctorTypeId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(nullable: false, maxLength: 50),
                        PracticeNo = c.String(nullable: false, maxLength: 20),
                        Address = c.String(nullable: false, maxLength: 1000),
                        Email = c.String(nullable: false, maxLength: 50),
                        PhoneNo = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.DoctorId)
                .ForeignKey("dbo.DoctorTypes", t => t.DoctorTypeId, cascadeDelete: true)
                .Index(t => t.DoctorTypeId);
            
            CreateTable(
                "dbo.DoctorTypes",
                c => new
                    {
                        DoctorTypeId = c.Int(nullable: false, identity: true),
                        DoctorTypeDescription = c.String(),
                    })
                .PrimaryKey(t => t.DoctorTypeId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        PaymentMethodId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(nullable: false, maxLength: 50),
                        IdNo = c.String(nullable: false, maxLength: 20),
                        Address = c.String(nullable: false, maxLength: 1000),
                        Email = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 50),
                        MedicalAidName = c.String(maxLength: 20),
                        MedicalAidNo = c.String(maxLength: 50),
                        MedicalAidPlan = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.PatientId)
                .ForeignKey("dbo.PaymentMethods", t => t.PaymentMethodId, cascadeDelete: true)
                .Index(t => t.PaymentMethodId);
            
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        PaymentMethodId = c.Int(nullable: false, identity: true),
                        PaymentMethodDescription = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.PaymentMethodId);
            
            CreateTable(
                "dbo.Consultations",
                c => new
                    {
                        ConsultationId = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        DiagnosisId = c.Int(nullable: false),
                        ConsultationTypeId = c.Int(nullable: false),
                        SymptomNotes = c.String(nullable: false, maxLength: 1000),
                        TreatmentNotes = c.String(nullable: false, maxLength: 1000),
                        Amount = c.Int(nullable: false),
                        Date = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ConsultationId)
                .ForeignKey("dbo.ConsultationTypes", t => t.ConsultationTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Diagnosis", t => t.DiagnosisId, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId)
                .Index(t => t.DiagnosisId)
                .Index(t => t.ConsultationTypeId);
            
            CreateTable(
                "dbo.ConsultationTypes",
                c => new
                    {
                        ConsultationTypeId = c.Int(nullable: false, identity: true),
                        ConsultationDescription = c.String(),
                    })
                .PrimaryKey(t => t.ConsultationTypeId);
            
            CreateTable(
                "dbo.Diagnosis",
                c => new
                    {
                        DiagnosisId = c.Int(nullable: false, identity: true),
                        DiagnosisDescription = c.String(),
                    })
                .PrimaryKey(t => t.DiagnosisId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        PaymentMethod = c.String(nullable: false, maxLength: 50),
                        Date = c.DateTime(nullable: false),
                        PaymentAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentId)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        IdNumber = c.String(maxLength: 20),
                        UserType = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Vaccinations",
                c => new
                    {
                        VaccinationId = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        VaccinationTypeId = c.Int(nullable: false),
                        Date = c.String(nullable: false),
                        Site = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.VaccinationId)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .ForeignKey("dbo.VaccinationTypes", t => t.VaccinationTypeId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.VaccinationTypeId);
            
            CreateTable(
                "dbo.VaccinationTypes",
                c => new
                    {
                        VaccinationTypeId = c.Int(nullable: false, identity: true),
                        VaccinationDescription = c.String(),
                    })
                .PrimaryKey(t => t.VaccinationTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vaccinations", "VaccinationTypeId", "dbo.VaccinationTypes");
            DropForeignKey("dbo.Vaccinations", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Payments", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Consultations", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Consultations", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Consultations", "DiagnosisId", "dbo.Diagnosis");
            DropForeignKey("dbo.Consultations", "ConsultationTypeId", "dbo.ConsultationTypes");
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Patients", "PaymentMethodId", "dbo.PaymentMethods");
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Doctors", "DoctorTypeId", "dbo.DoctorTypes");
            DropIndex("dbo.Vaccinations", new[] { "VaccinationTypeId" });
            DropIndex("dbo.Vaccinations", new[] { "PatientId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Payments", new[] { "PatientId" });
            DropIndex("dbo.Consultations", new[] { "ConsultationTypeId" });
            DropIndex("dbo.Consultations", new[] { "DiagnosisId" });
            DropIndex("dbo.Consultations", new[] { "DoctorId" });
            DropIndex("dbo.Consultations", new[] { "PatientId" });
            DropIndex("dbo.Patients", new[] { "PaymentMethodId" });
            DropIndex("dbo.Doctors", new[] { "DoctorTypeId" });
            DropIndex("dbo.Appointments", new[] { "PatientId" });
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            DropTable("dbo.VaccinationTypes");
            DropTable("dbo.Vaccinations");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Users");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Payments");
            DropTable("dbo.Diagnosis");
            DropTable("dbo.ConsultationTypes");
            DropTable("dbo.Consultations");
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.Patients");
            DropTable("dbo.DoctorTypes");
            DropTable("dbo.Doctors");
            DropTable("dbo.Appointments");
        }
    }
}
