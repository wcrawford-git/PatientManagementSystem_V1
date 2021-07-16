namespace PatientManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDoctor2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorId = c.Int(nullable: false, identity: true),
                        DoctorTypeId = c.Int(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        practice_no = c.String(),
                        address = c.String(),
                        email = c.String(),
                        phone_no = c.String(),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "DoctorTypeId", "dbo.DoctorTypes");
            DropIndex("dbo.Doctors", new[] { "DoctorTypeId" });
            DropTable("dbo.DoctorTypes");
            DropTable("dbo.Doctors");
        }
    }
}
