namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 32),
                        Credit = c.Double(nullable: false),
                        Name = c.String(maxLength: 32),
                        Description = c.String(),
                        DepartmentId = c.Int(nullable: false),
                        SemesterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Semesters", t => t.SemesterId, cascadeDelete: true)
                .Index(t => t.Code, unique: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.SemesterId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentCode = c.String(nullable: false, maxLength: 32),
                        DepartmentName = c.String(nullable: false, maxLength: 32),
                    })
                .PrimaryKey(t => t.DepartmentId)
                .Index(t => t.DepartmentCode, unique: true)
                .Index(t => t.DepartmentName, unique: true);
            
            CreateTable(
                "dbo.Semesters",
                c => new
                    {
                        SemesterId = c.Int(nullable: false, identity: true),
                        SemesterNO = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SemesterId);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        DesignationId = c.Int(nullable: false, identity: true),
                        DesignationName = c.String(),
                    })
                .PrimaryKey(t => t.DesignationId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(),
                        Email = c.String(nullable: false, maxLength: 32),
                        ContactNo = c.String(),
                        DesignationId = c.String(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        Credit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Designation_DesignationId = c.Int(),
                    })
                .PrimaryKey(t => t.TeacherId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Designations", t => t.Designation_DesignationId)
                .Index(t => t.Email, unique: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.Designation_DesignationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "Designation_DesignationId", "dbo.Designations");
            DropForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Courses", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Teachers", new[] { "Designation_DesignationId" });
            DropIndex("dbo.Teachers", new[] { "DepartmentId" });
            DropIndex("dbo.Teachers", new[] { "Email" });
            DropIndex("dbo.Departments", new[] { "DepartmentName" });
            DropIndex("dbo.Departments", new[] { "DepartmentCode" });
            DropIndex("dbo.Courses", new[] { "SemesterId" });
            DropIndex("dbo.Courses", new[] { "DepartmentId" });
            DropIndex("dbo.Courses", new[] { "Name" });
            DropIndex("dbo.Courses", new[] { "Code" });
            DropTable("dbo.Teachers");
            DropTable("dbo.Designations");
            DropTable("dbo.Semesters");
            DropTable("dbo.Departments");
            DropTable("dbo.Courses");
        }
    }
}
