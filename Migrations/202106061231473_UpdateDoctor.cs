namespace PatientManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDoctor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "PracticeNo", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Doctors", "PhoneNo", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Doctors", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Doctors", "Surname", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Doctors", "Address", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.Doctors", "Email", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Doctors", "practice_no");
            DropColumn("dbo.Doctors", "phone_no");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Doctors", "phone_no", c => c.String());
            AddColumn("dbo.Doctors", "practice_no", c => c.String());
            AlterColumn("dbo.Doctors", "Email", c => c.String());
            AlterColumn("dbo.Doctors", "Address", c => c.String());
            AlterColumn("dbo.Doctors", "Surname", c => c.String());
            AlterColumn("dbo.Doctors", "Name", c => c.String());
            DropColumn("dbo.Doctors", "PhoneNo");
            DropColumn("dbo.Doctors", "PracticeNo");
        }
    }
}
