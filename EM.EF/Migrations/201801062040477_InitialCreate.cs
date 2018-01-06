namespace EM.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DefaultTemplates",
                c => new
                    {
                        FullClassName = c.String(nullable: false, maxLength: 128),
                        DLLName = c.String(),
                    })
                .PrimaryKey(t => t.FullClassName);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DefaultTemplates");
        }
    }
}
