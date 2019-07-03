namespace project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ee : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.OrderDetails", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.OrderDetails", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetails", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.OrderDetails", "ApplicationUser_Id");
            AddForeignKey("dbo.OrderDetails", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
