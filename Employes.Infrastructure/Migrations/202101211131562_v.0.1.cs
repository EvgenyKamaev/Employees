namespace Employes.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Floor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Employes",
                c => new
                    {
                        EmployeId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        Gender = c.String(),
                        ExperienceId = c.Int(nullable: false),
                        Department_DepartmentId = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeId)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentId)
                .ForeignKey("dbo.Experiences", t => t.ExperienceId, cascadeDelete: true)
                .Index(t => t.ExperienceId)
                .Index(t => t.Department_DepartmentId);
            
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        ExperienceId = c.Int(nullable: false, identity: true),
                        LanguageId = c.Int(nullable: false),
                        Employe_EmployeId = c.Int(),
                    })
                .PrimaryKey(t => t.ExperienceId)
                .ForeignKey("dbo.Employes", t => t.Employe_EmployeId)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId)
                .Index(t => t.Employe_EmployeId);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        LanguageId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.LanguageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employes", "ExperienceId", "dbo.Experiences");
            DropForeignKey("dbo.Experiences", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.Experiences", "Employe_EmployeId", "dbo.Employes");
            DropForeignKey("dbo.Employes", "Department_DepartmentId", "dbo.Departments");
            DropIndex("dbo.Experiences", new[] { "Employe_EmployeId" });
            DropIndex("dbo.Experiences", new[] { "LanguageId" });
            DropIndex("dbo.Employes", new[] { "Department_DepartmentId" });
            DropIndex("dbo.Employes", new[] { "ExperienceId" });
            DropTable("dbo.Languages");
            DropTable("dbo.Experiences");
            DropTable("dbo.Employes");
            DropTable("dbo.Departments");
        }
    }
}
