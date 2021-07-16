namespace PatientManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateConsultation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Consultations", "AppointmentId", "dbo.Appointments");
            DropIndex("dbo.Consultations", new[] { "AppointmentId" });
            AlterColumn("dbo.Consultations", "SymptomNotes", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.Consultations", "TreatmentNotes", c => c.String(nullable: false, maxLength: 1000));
            DropColumn("dbo.Consultations", "AppointmentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Consultations", "AppointmentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Consultations", "TreatmentNotes", c => c.Int(nullable: false));
            AlterColumn("dbo.Consultations", "SymptomNotes", c => c.String());
            CreateIndex("dbo.Consultations", "AppointmentId");
            AddForeignKey("dbo.Consultations", "AppointmentId", "dbo.Appointments", "AppointmentId", cascadeDelete: true);
        }
    }
}
