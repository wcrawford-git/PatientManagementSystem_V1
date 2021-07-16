namespace PatientManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDiagCons : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConsultationTypes",
                c => new
                    {
                        ConsultationTypeId = c.Int(nullable: false, identity: true),
                        ConsultationDescription = c.String(),
                    })
                .PrimaryKey(t => t.ConsultationTypeId);
            
            CreateTable(
                "dbo.Diagnosis",
                c => new
                    {
                        DiagnosisId = c.Int(nullable: false, identity: true),
                        DiagnosisDescription = c.String(),
                    })
                .PrimaryKey(t => t.DiagnosisId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Diagnosis");
            DropTable("dbo.ConsultationTypes");
        }
    }
}
