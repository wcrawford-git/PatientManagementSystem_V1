namespace PatientManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePaymentmethod : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Payments", "ConsultationId", "dbo.Consultations");
            DropIndex("dbo.Payments", new[] { "ConsultationId" });
            AddColumn("dbo.Payments", "PatientId", c => c.Int(nullable: false));
            AlterColumn("dbo.Payments", "PaymentMethod", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Payments", "PatientId");
            AddForeignKey("dbo.Payments", "PatientId", "dbo.Patients", "PatientId", cascadeDelete: true);
            DropColumn("dbo.Consultations", "IsPaid");
            DropColumn("dbo.Payments", "ConsultationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "ConsultationId", c => c.Int(nullable: false));
            AddColumn("dbo.Consultations", "IsPaid", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Payments", "PatientId", "dbo.Patients");
            DropIndex("dbo.Payments", new[] { "PatientId" });
            AlterColumn("dbo.Payments", "PaymentMethod", c => c.String());
            DropColumn("dbo.Payments", "PatientId");
            CreateIndex("dbo.Payments", "ConsultationId");
            AddForeignKey("dbo.Payments", "ConsultationId", "dbo.Consultations", "ConsultationId", cascadeDelete: true);
        }
    }
}
