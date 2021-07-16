namespace PatientManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertDoctorTypes : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[DoctorTypes] ([DoctorTypeDescription]) VALUES (N'Dermatologist')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
