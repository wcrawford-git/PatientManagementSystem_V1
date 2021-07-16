namespace PatientManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateConsultationisPaid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Consultations", "IsPaid", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Consultations", "IsPaid");
        }
    }
}
