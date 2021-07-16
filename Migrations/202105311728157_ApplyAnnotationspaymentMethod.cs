namespace PatientManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationspaymentMethod : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PaymentMethods", "PaymentMethodDescription", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PaymentMethods", "PaymentMethodDescription", c => c.String());
        }
    }
}
