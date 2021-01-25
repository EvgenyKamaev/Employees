namespace Employes.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v05 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employes", "Language_LanguageId", c => c.Int());
            CreateIndex("dbo.Employes", "Language_LanguageId");
            AddForeignKey("dbo.Employes", "Language_LanguageId", "dbo.Languages", "LanguageId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employes", "Language_LanguageId", "dbo.Languages");
            DropIndex("dbo.Employes", new[] { "Language_LanguageId" });
            DropColumn("dbo.Employes", "Language_LanguageId");
        }
    }
}
