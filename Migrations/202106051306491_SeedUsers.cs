namespace PatientManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0c94f1a0-ac0c-41b7-9f9f-57ce6b8ba5fd', N'guest@pms.com', 0, N'AIYsX5b/3noefOAtK30osfQQTmeutQbb+ftFia+soPT7ThaKHlDrlC5MzZ9rc6BSew==', N'0da1eadd-dc34-4f53-acb9-076b1d6d66d5', NULL, 0, 0, NULL, 1, 0, N'guest@pms.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3966ff96-c90c-406d-ac65-d78d6fe8bd74', N'admin@pms.com', 0, N'ANVEZgjT51rMblQKCRT2p56r8Y79oIK5YYqJ5XbM1xDCZWzZ9hPoStbSfCyz9An6Vg==', N'a0419cad-93f7-4069-88ce-91466284e16e', NULL, 0, 0, NULL, 1, 0, N'admin@pms.com')
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3210c7fb-50ad-4750-903e-79af6d3176ab', N'CanManagePatients')
                
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3966ff96-c90c-406d-ac65-d78d6fe8bd74', N'3210c7fb-50ad-4750-903e-79af6d3176ab')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
