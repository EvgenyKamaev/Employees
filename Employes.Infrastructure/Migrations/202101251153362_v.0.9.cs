namespace Employes.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v09 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Experiences", "LanguageId");
            AddForeignKey("dbo.Experiences", "LanguageId", "dbo.Languages", "LanguageId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Experiences", "LanguageId", "dbo.Languages");
            DropIndex("dbo.Experiences", new[] { "LanguageId" });
        }
    }
}
