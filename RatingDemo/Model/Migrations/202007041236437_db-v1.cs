namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        passCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        question = c.String(),
                        Servicecs_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Servicecs", t => t.Servicecs_Id)
                .Index(t => t.Servicecs_Id);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        idQuestion = c.Int(nullable: false),
                        Scores = c.Int(nullable: false),
                        comment = c.String(),
                        CreateDay = c.DateTime(),
                        idService = c.Int(nullable: false),
                        Employee_Id = c.Guid(),
                        Servicecs_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .ForeignKey("dbo.Servicecs", t => t.Servicecs_Id)
                .Index(t => t.Employee_Id)
                .Index(t => t.Servicecs_Id);
            
            CreateTable(
                "dbo.Servicecs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "Servicecs_Id", "dbo.Servicecs");
            DropForeignKey("dbo.Questions", "Servicecs_Id", "dbo.Servicecs");
            DropForeignKey("dbo.Ratings", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.Ratings", new[] { "Servicecs_Id" });
            DropIndex("dbo.Ratings", new[] { "Employee_Id" });
            DropIndex("dbo.Questions", new[] { "Servicecs_Id" });
            DropTable("dbo.Servicecs");
            DropTable("dbo.Ratings");
            DropTable("dbo.Questions");
            DropTable("dbo.Employees");
        }
    }
}
