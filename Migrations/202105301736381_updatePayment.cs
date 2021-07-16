namespace PatientManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePayment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        ConsultationId = c.Int(nullable: false),
                        PaymentMethod = c.String(),
                        Date = c.DateTime(nullable: false),
                        PaymentAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentId)
                .ForeignKey("dbo.Consultations", t => t.ConsultationId, cascadeDelete: true)
                .Index(t => t.ConsultationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "ConsultationId", "dbo.Consultations");
            DropIndex("dbo.Payments", new[] { "ConsultationId" });
            DropTable("dbo.Payments");
        }
    }
}
