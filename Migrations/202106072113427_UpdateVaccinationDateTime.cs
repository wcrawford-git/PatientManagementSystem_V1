namespace PatientManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateVaccinationDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vaccinations", "Date", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vaccinations", "Date", c => c.DateTime(nullable: false));
        }
    }
}
