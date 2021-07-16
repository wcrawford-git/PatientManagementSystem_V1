namespace PatientManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAppointment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "DoctorId", c => c.Int(nullable: false));
            AddColumn("dbo.Appointments", "PatientId", c => c.Int(nullable: false));
            CreateIndex("dbo.Appointments", "DoctorId");
            CreateIndex("dbo.Appointments", "PatientId");
            AddForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors", "DoctorId", cascadeDelete: true);
            AddForeignKey("dbo.Appointments", "PatientId", "dbo.Patients", "PatientId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Appointments", new[] { "PatientId" });
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            DropColumn("dbo.Appointments", "PatientId");
            DropColumn("dbo.Appointments", "DoctorId");
        }
    }
}
