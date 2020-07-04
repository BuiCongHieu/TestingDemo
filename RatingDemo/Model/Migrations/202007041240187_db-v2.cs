namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbv2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ratings", "Servicecs_Id", "dbo.Servicecs");
            DropIndex("dbo.Ratings", new[] { "Servicecs_Id" });
            DropColumn("dbo.Ratings", "Servicecs_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ratings", "Servicecs_Id", c => c.Int());
            CreateIndex("dbo.Ratings", "Servicecs_Id");
            AddForeignKey("dbo.Ratings", "Servicecs_Id", "dbo.Servicecs", "Id");
        }
    }
}
