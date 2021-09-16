namespace UFESManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BackToNormal : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Tests");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        TestId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TestId);
            
        }
    }
}
