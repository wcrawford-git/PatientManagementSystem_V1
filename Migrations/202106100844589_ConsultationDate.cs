namespace PatientManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConsultationDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Consultations", "Date", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Consultations", "Date");
        }
    }
}
