namespace PatientManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateVaccinationDateTime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vaccinations", "Date", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vaccinations", "Date", c => c.String(nullable: false));
        }
    }
}
