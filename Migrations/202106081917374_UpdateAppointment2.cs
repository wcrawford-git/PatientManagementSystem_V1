namespace PatientManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAppointment2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "Time", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "Time");
        }
    }
}
