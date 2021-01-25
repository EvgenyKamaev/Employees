namespace Employes.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v08 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Experiences", "LanguageId", "dbo.Languages");
            DropIndex("dbo.Experiences", new[] { "LanguageId" });
            AddColumn("dbo.Experiences", "EmployeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Experiences", "EmployeId");
            CreateIndex("dbo.Experiences", "LanguageId");
            AddForeignKey("dbo.Experiences", "LanguageId", "dbo.Languages", "LanguageId", cascadeDelete: true);
        }
    }
}
