namespace project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class step4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.OrderDetails", "ApplicationUser_Id");
            AddForeignKey("dbo.OrderDetails", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.OrderDetails", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.OrderDetails", "ApplicationUser_Id");
        }
    }
}
