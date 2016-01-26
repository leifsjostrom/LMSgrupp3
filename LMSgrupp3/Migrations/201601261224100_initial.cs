namespace LMSgrupp3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourceModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        TeacherId = c.String(nullable: false, maxLength: 128),
                        StudentNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TeacherModels", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId);
            
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
                        CourceId = c.Int(nullable: false),
                        Shared = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SchemaModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherEmplymentNumber = c.String(nullable: false, maxLength: 128),
                        CourceId = c.Int(nullable: false),
                        Location = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourceModels", t => t.CourceId, cascadeDelete: true)
                .ForeignKey("dbo.TeacherModels", t => t.TeacherEmplymentNumber, cascadeDelete: true)
                .Index(t => t.TeacherEmplymentNumber)
                .Index(t => t.CourceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SchemaModels", "TeacherEmplymentNumber", "dbo.TeacherModels");
            DropForeignKey("dbo.SchemaModels", "CourceId", "dbo.CourceModels");
            DropForeignKey("dbo.CourceModels", "TeacherId", "dbo.TeacherModels");
            DropForeignKey("dbo.StudentModels", "CourceModel_Id", "dbo.CourceModels");
            DropIndex("dbo.SchemaModels", new[] { "CourceId" });
            DropIndex("dbo.SchemaModels", new[] { "TeacherEmplymentNumber" });
            DropIndex("dbo.StudentModels", new[] { "CourceModel_Id" });
            DropIndex("dbo.CourceModels", new[] { "TeacherId" });
            DropTable("dbo.SchemaModels");
            DropTable("dbo.FileModels");
            DropTable("dbo.TeacherModels");
            DropTable("dbo.StudentModels");
            DropTable("dbo.CourceModels");
        }
    }
}
