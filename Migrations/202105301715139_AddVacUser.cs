namespace PatientManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVacUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        IdNumber = c.String(),
                        UserType = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
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
            DropTable("dbo.VaccinationTypes");
            DropTable("dbo.Users");
        }
    }
}
