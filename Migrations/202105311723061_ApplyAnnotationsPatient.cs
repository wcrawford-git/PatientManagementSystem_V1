namespace PatientManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsPatient : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patients", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Patients", "Surname", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Patients", "IdNo", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Patients", "Address", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.Patients", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Patients", "Phone", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Patients", "MedicalAidName", c => c.String(maxLength: 20));
            AlterColumn("dbo.Patients", "MedicalAidNo", c => c.String(maxLength: 50));
            AlterColumn("dbo.Patients", "MedicalAidPlan", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "MedicalAidPlan", c => c.String());
            AlterColumn("dbo.Patients", "MedicalAidNo", c => c.String());
            AlterColumn("dbo.Patients", "MedicalAidName", c => c.String());
            AlterColumn("dbo.Patients", "Phone", c => c.String());
            AlterColumn("dbo.Patients", "Email", c => c.String());
            AlterColumn("dbo.Patients", "Address", c => c.String());
            AlterColumn("dbo.Patients", "IdNo", c => c.String());
            AlterColumn("dbo.Patients", "Surname", c => c.String());
            AlterColumn("dbo.Patients", "Name", c => c.String());
        }
    }
}
