namespace Employes.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v06 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employes", "Language_LanguageId", "dbo.Languages");
            DropForeignKey("dbo.Experiences", "Employe_EmployeId", "dbo.Employes");
            DropIndex("dbo.Employes", new[] { "Language_LanguageId" });
            DropIndex("dbo.Experiences", new[] { "Employe_EmployeId" });
            AddColumn("dbo.Employes", "Experience_ExperienceId", c => c.Int());
            CreateIndex("dbo.Employes", "Experience_ExperienceId");
            AddForeignKey("dbo.Employes", "Experience_ExperienceId", "dbo.Experiences", "ExperienceId");
            DropColumn("dbo.Employes", "Language_LanguageId");
            DropColumn("dbo.Experiences", "Employe_EmployeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Experiences", "Employe_EmployeId", c => c.Int());
            AddColumn("dbo.Employes", "Language_LanguageId", c => c.Int());
            DropForeignKey("dbo.Employes", "Experience_ExperienceId", "dbo.Experiences");
            DropIndex("dbo.Employes", new[] { "Experience_ExperienceId" });
            DropColumn("dbo.Employes", "Experience_ExperienceId");
            CreateIndex("dbo.Experiences", "Employe_EmployeId");
            CreateIndex("dbo.Employes", "Language_LanguageId");
            AddForeignKey("dbo.Experiences", "Employe_EmployeId", "dbo.Employes", "EmployeId");
            AddForeignKey("dbo.Employes", "Language_LanguageId", "dbo.Languages", "LanguageId");
        }
    }
}
