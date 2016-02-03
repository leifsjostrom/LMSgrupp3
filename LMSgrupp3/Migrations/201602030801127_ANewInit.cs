namespace LMSgrupp3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ANewInit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourceModels", "Teacher_EmplymentNumber", "dbo.TeacherModels");
            DropIndex("dbo.CourceModels", new[] { "Teacher_EmplymentNumber" });
            AlterColumn("dbo.CourceModels", "Teacher_EmplymentNumber", c => c.String(maxLength: 128));
            CreateIndex("dbo.CourceModels", "Teacher_EmplymentNumber");
            AddForeignKey("dbo.CourceModels", "Teacher_EmplymentNumber", "dbo.TeacherModels", "EmplymentNumber");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourceModels", "Teacher_EmplymentNumber", "dbo.TeacherModels");
            DropIndex("dbo.CourceModels", new[] { "Teacher_EmplymentNumber" });
            AlterColumn("dbo.CourceModels", "Teacher_EmplymentNumber", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.CourceModels", "Teacher_EmplymentNumber");
            AddForeignKey("dbo.CourceModels", "Teacher_EmplymentNumber", "dbo.TeacherModels", "EmplymentNumber", cascadeDelete: true);
        }
    }
}
