namespace LMSgrupp3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SchemaModels", "TeacherId", "dbo.TeacherModels");
            DropIndex("dbo.SchemaModels", new[] { "TeacherId" });
            AlterColumn("dbo.SchemaModels", "TeacherId", c => c.String(maxLength: 128));
            CreateIndex("dbo.SchemaModels", "TeacherId");
            AddForeignKey("dbo.SchemaModels", "TeacherId", "dbo.TeacherModels", "EmplymentNumber");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SchemaModels", "TeacherId", "dbo.TeacherModels");
            DropIndex("dbo.SchemaModels", new[] { "TeacherId" });
            AlterColumn("dbo.SchemaModels", "TeacherId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.SchemaModels", "TeacherId");
            AddForeignKey("dbo.SchemaModels", "TeacherId", "dbo.TeacherModels", "EmplymentNumber", cascadeDelete: true);
        }
    }
}
