namespace PatientManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnLinkIdentityUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Doctors", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Doctors", new[] { "UserId" });
            DropColumn("dbo.Doctors", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Doctors", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Doctors", "UserId");
            AddForeignKey("dbo.Doctors", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
