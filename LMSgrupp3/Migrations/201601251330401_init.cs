namespace LMSgrupp3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourceModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Teacher_EmplymentNumber = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TeacherModels", t => t.Teacher_EmplymentNumber, cascadeDelete: true)
                .Index(t => t.Teacher_EmplymentNumber);
            
            CreateTable(
                "dbo.StudentModels",
                c => new
                    {
                        StudentNumber = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Adress = c.String(nullable: false),
                        Town = c.String(nullable: false),
                        ZipCode = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        CourceModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.StudentNumber)
                .ForeignKey("dbo.CourceModels", t => t.CourceModel_Id)
                .Index(t => t.CourceModel_Id);
            
            CreateTable(
                "dbo.TeacherModels",
                c => new
                    {
                        EmplymentNumber = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Adress = c.String(nullable: false),
                        Town = c.String(nullable: false),
                        ZipCode = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EmplymentNumber);
            
            CreateTable(
                "dbo.FileModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Subject = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Shared = c.Boolean(nullable: false),
                        Cource_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourceModels", t => t.Cource_Id, cascadeDelete: true)
                .Index(t => t.Cource_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FileModels", "Cource_Id", "dbo.CourceModels");
            DropForeignKey("dbo.CourceModels", "Teacher_EmplymentNumber", "dbo.TeacherModels");
            DropForeignKey("dbo.StudentModels", "CourceModel_Id", "dbo.CourceModels");
            DropIndex("dbo.FileModels", new[] { "Cource_Id" });
            DropIndex("dbo.StudentModels", new[] { "CourceModel_Id" });
            DropIndex("dbo.CourceModels", new[] { "Teacher_EmplymentNumber" });
            DropTable("dbo.FileModels");
            DropTable("dbo.TeacherModels");
            DropTable("dbo.StudentModels");
            DropTable("dbo.CourceModels");
        }
    }
}
