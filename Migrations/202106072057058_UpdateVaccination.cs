namespace PatientManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateVaccination : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vaccinations", "Site", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vaccinations", "Site", c => c.String());
        }
    }
}
