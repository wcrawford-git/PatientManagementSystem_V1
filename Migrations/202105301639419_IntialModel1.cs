namespace PatientManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialModel1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        PaymentMethodId = c.Int(nullable: false),
                        Name = c.String(),
                        SurnameName = c.String(),
                        IdNo = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        MedicalAidName = c.String(),
                        MedicalAidNo = c.String(),
                        MedicalAidPlan = c.String(),
                    })
                .PrimaryKey(t => t.PatientId)
                .ForeignKey("dbo.PaymentMethods", t => t.PaymentMethodId, cascadeDelete: true)
                .Index(t => t.PaymentMethodId);
            
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        PaymentMethodId = c.Int(nullable: false, identity: true),
                        PaymentMethodDescription = c.String(),
                    })
                .PrimaryKey(t => t.PaymentMethodId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "PaymentMethodId", "dbo.PaymentMethods");
            DropIndex("dbo.Patients", new[] { "PaymentMethodId" });
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.Patients");
        }
    }
}
