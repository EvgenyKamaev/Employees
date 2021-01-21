namespace Employes.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v02 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employes", "ExperienceId", "dbo.Experiences");
            DropIndex("dbo.Employes", new[] { "ExperienceId" });
            DropColumn("dbo.Employes", "ExperienceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employes", "ExperienceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employes", "ExperienceId");
            AddForeignKey("dbo.Employes", "ExperienceId", "dbo.Experiences", "ExperienceId", cascadeDelete: true);
        }
    }
}
