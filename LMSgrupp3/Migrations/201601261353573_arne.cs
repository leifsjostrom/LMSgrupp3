namespace LMSgrupp3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arne : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourceModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        TeacherId = c.String(),
                        StudentNumber = c.String(),
                        FileModel_Id = c.Int(),
                        Teacher_EmplymentNumber = c.String(nullable: false, maxLength: 128),
                        SchemaModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FileModels", t => t.FileModel_Id)
                .ForeignKey("dbo.TeacherModels", t => t.Teacher_EmplymentNumber, cascadeDelete: true)
                .ForeignKey("dbo.SchemaModels", t => t.SchemaModel_Id)
                .Index(t => t.FileModel_Id)
                .Index(t => t.Teacher_EmplymentNumber)
                .Index(t => t.SchemaModel_Id);
            
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
                        FileId = c.Int(nullable: false),
                        CourceModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.StudentNumber)
                .ForeignKey("dbo.CourceModels", t => t.CourceModel_Id)
                .Index(t => t.CourceModel_Id);
            
            CreateTable(
                "dbo.FileModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Subject = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Shared = c.Boolean(nullable: false),
                        CourceId = c.Int(nullable: false),
                        StudentNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        CourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmplymentNumber);
            
            CreateTable(
                "dbo.SchemaModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherId = c.String(nullable: false, maxLength: 128),
                        CourceId = c.Int(nullable: false),
                        Location = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TeacherModels", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.FileModelStudentModels",
                c => new
                    {
                        FileModel_Id = c.Int(nullable: false),
                        StudentModel_StudentNumber = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FileModel_Id, t.StudentModel_StudentNumber })
                .ForeignKey("dbo.FileModels", t => t.FileModel_Id, cascadeDelete: true)
                .ForeignKey("dbo.StudentModels", t => t.StudentModel_StudentNumber, cascadeDelete: true)
                .Index(t => t.FileModel_Id)
                .Index(t => t.StudentModel_StudentNumber);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SchemaModels", "TeacherId", "dbo.TeacherModels");
            DropForeignKey("dbo.CourceModels", "SchemaModel_Id", "dbo.SchemaModels");
            DropForeignKey("dbo.CourceModels", "Teacher_EmplymentNumber", "dbo.TeacherModels");
            DropForeignKey("dbo.StudentModels", "CourceModel_Id", "dbo.CourceModels");
            DropForeignKey("dbo.FileModelStudentModels", "StudentModel_StudentNumber", "dbo.StudentModels");
            DropForeignKey("dbo.FileModelStudentModels", "FileModel_Id", "dbo.FileModels");
            DropForeignKey("dbo.CourceModels", "FileModel_Id", "dbo.FileModels");
            DropIndex("dbo.FileModelStudentModels", new[] { "StudentModel_StudentNumber" });
            DropIndex("dbo.FileModelStudentModels", new[] { "FileModel_Id" });
            DropIndex("dbo.SchemaModels", new[] { "TeacherId" });
            DropIndex("dbo.StudentModels", new[] { "CourceModel_Id" });
            DropIndex("dbo.CourceModels", new[] { "SchemaModel_Id" });
            DropIndex("dbo.CourceModels", new[] { "Teacher_EmplymentNumber" });
            DropIndex("dbo.CourceModels", new[] { "FileModel_Id" });
            DropTable("dbo.FileModelStudentModels");
            DropTable("dbo.SchemaModels");
            DropTable("dbo.TeacherModels");
            DropTable("dbo.FileModels");
            DropTable("dbo.StudentModels");
            DropTable("dbo.CourceModels");
        }
    }
}
