namespace LMSgrupp3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ANewInit1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SchemViews",
                c => new
                    {
                        Idp = c.Int(nullable: false, identity: true),
                        time = c.String(),
                        Day1 = c.String(),
                        Day2 = c.String(),
                        Day3 = c.String(),
                        Day4 = c.String(),
                        Day5 = c.String(),
                        Day6 = c.String(),
                        Day7 = c.String(),
                    })
                .PrimaryKey(t => t.Idp);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SchemViews");
        }
    }
}
