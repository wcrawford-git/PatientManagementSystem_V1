namespace PatientManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertPaymentMethods : DbMigration
    {
        public override void Up()
        {
           // Sql("INSERT INTO PaymentMethod(PaymentMethodDescription)" +
           //     "VALUES('Medical Aid')");

            Sql("INSERT INTO PaymentMethods(PaymentMethodDescription)" +
           "VALUES('Cash')");

        }

        public override void Down()
        {
        }
    }
}
