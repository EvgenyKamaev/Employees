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
                "dbo.Languages",
                c => new
                    {
                        LanguageId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.LanguageId);
            
            CreateTable(
                "dbo.Employes",
                c => new
                    {
                        EmployeId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Department_DepartmentId = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeId)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentId)
                .Index(t => t.Department_DepartmentId);
            
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        EmployeId = c.Int(nullable: false, identity: true),
                        LanguageId = c.Int(nullable: false),
                        EmployesDomain_EmployeId = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeId)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .ForeignKey("dbo.Employes", t => t.EmployesDomain_EmployeId)
                .Index(t => t.LanguageId)
                .Index(t => t.EmployesDomain_EmployeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Experiences", "EmployesDomain_EmployeId", "dbo.Employes");
            DropForeignKey("dbo.Experiences", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.Employes", "Department_DepartmentId", "dbo.Departments");
            DropIndex("dbo.Experiences", new[] { "EmployesDomain_EmployeId" });
            DropIndex("dbo.Experiences", new[] { "LanguageId" });
            DropIndex("dbo.Employes", new[] { "Department_DepartmentId" });
            DropTable("dbo.Experiences");
            DropTable("dbo.Employes");
            DropTable("dbo.Languages");
            DropTable("dbo.Departments");
        }
    }
}
