namespace PatientManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsUser2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "Surname", c => c.String());
            AlterColumn("dbo.Users", "IdNumber", c => c.String(maxLength: 20));
            DropColumn("dbo.Patients", "SurnameName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "SurnameName", c => c.String());
            AlterColumn("dbo.Users", "IdNumber", c => c.String());
            DropColumn("dbo.Patients", "Surname");
        }
    }
}
