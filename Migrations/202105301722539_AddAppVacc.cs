namespace PatientManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAppVacc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        AppointmentId = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AppointmentId);
            
            CreateTable(
                "dbo.Vaccinations",
                c => new
                    {
                        VaccinationId = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        VaccinationTypeId = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                        Site = c.String(),
                    })
                .PrimaryKey(t => t.VaccinationId)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .ForeignKey("dbo.VaccinationTypes", t => t.VaccinationTypeId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.VaccinationTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vaccinations", "VaccinationTypeId", "dbo.VaccinationTypes");
            DropForeignKey("dbo.Vaccinations", "PatientId", "dbo.Patients");
            DropIndex("dbo.Vaccinations", new[] { "VaccinationTypeId" });
            DropIndex("dbo.Vaccinations", new[] { "PatientId" });
            DropTable("dbo.Vaccinations");
            DropTable("dbo.Appointments");
        }
    }
}
