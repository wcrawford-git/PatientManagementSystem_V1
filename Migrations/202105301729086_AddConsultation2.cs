namespace PatientManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConsultation2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consultations",
                c => new
                    {
                        ConsultationId = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        AppointmentId = c.Int(nullable: false),
                        DiagnosisId = c.Int(nullable: false),
                        ConsultationTypeId = c.Int(nullable: false),
                        SymptomNotes = c.String(),
                        TreatmentNotes = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ConsultationId)
                .ForeignKey("dbo.Appointments", t => t.AppointmentId, cascadeDelete: true)
                .ForeignKey("dbo.ConsultationTypes", t => t.ConsultationTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Diagnosis", t => t.DiagnosisId, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId)
                .Index(t => t.AppointmentId)
                .Index(t => t.DiagnosisId)
                .Index(t => t.ConsultationTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Consultations", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Consultations", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Consultations", "DiagnosisId", "dbo.Diagnosis");
            DropForeignKey("dbo.Consultations", "ConsultationTypeId", "dbo.ConsultationTypes");
            DropForeignKey("dbo.Consultations", "AppointmentId", "dbo.Appointments");
            DropIndex("dbo.Consultations", new[] { "ConsultationTypeId" });
            DropIndex("dbo.Consultations", new[] { "DiagnosisId" });
            DropIndex("dbo.Consultations", new[] { "AppointmentId" });
            DropIndex("dbo.Consultations", new[] { "DoctorId" });
            DropIndex("dbo.Consultations", new[] { "PatientId" });
            DropTable("dbo.Consultations");
        }
    }
}
