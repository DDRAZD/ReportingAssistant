namespace ReportingAssistant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "nameofschema.Categories",
                c => new
                    {
                        CategoryID = c.Long(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "nameofschema.Final Comments",
                c => new
                    {
                        FinalCommentID = c.Long(nullable: false, identity: true),
                        Screen = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false),
                        AdminUserId = c.String(maxLength: 128),
                        UserID = c.String(maxLength: 128),
                        DateOfFinalComment = c.DateTime(nullable: false),
                        Attachment = c.String(),
                        ProjectID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.FinalCommentID)
                .ForeignKey("dbo.AspNetUsers", t => t.AdminUserId)
                .ForeignKey("nameofschema.Projects", t => t.ProjectID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.AdminUserId)
                .Index(t => t.UserID)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Address = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "nameofschema.Projects",
                c => new
                    {
                        ProjectID = c.Long(nullable: false, identity: true),
                        ProjectName = c.String(nullable: false),
                        DateOfStart = c.DateTime(),
                        AvailablityStatus = c.String(nullable: false),
                        CategoryID = c.Long(nullable: false),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.ProjectID)
                .ForeignKey("nameofschema.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "nameofschema.Tasks",
                c => new
                    {
                        TaskID = c.Long(nullable: false, identity: true),
                        Screen = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false),
                        AdminUserId = c.String(maxLength: 128),
                        UserID = c.String(maxLength: 128),
                        DateOfTask = c.DateTime(nullable: false),
                        Attachment = c.String(),
                        ProjectID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.TaskID)
                .ForeignKey("dbo.AspNetUsers", t => t.AdminUserId)
                .ForeignKey("nameofschema.Projects", t => t.ProjectID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.AdminUserId)
                .Index(t => t.UserID)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "nameofschema.TasksDone",
                c => new
                    {
                        TaskDoneID = c.Long(nullable: false, identity: true),
                        Screen = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false),
                        AdminUserId = c.String(maxLength: 128),
                        UserID = c.String(maxLength: 128),
                        DateOfTaskDone = c.DateTime(nullable: false),
                        Attachment = c.String(),
                        ProjectID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.TaskDoneID)
                .ForeignKey("dbo.AspNetUsers", t => t.AdminUserId)
                .ForeignKey("nameofschema.Projects", t => t.ProjectID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.AdminUserId)
                .Index(t => t.UserID)
                .Index(t => t.ProjectID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("nameofschema.TasksDone", "UserID", "dbo.AspNetUsers");
            DropForeignKey("nameofschema.TasksDone", "ProjectID", "nameofschema.Projects");
            DropForeignKey("nameofschema.TasksDone", "AdminUserId", "dbo.AspNetUsers");
            DropForeignKey("nameofschema.Tasks", "UserID", "dbo.AspNetUsers");
            DropForeignKey("nameofschema.Tasks", "ProjectID", "nameofschema.Projects");
            DropForeignKey("nameofschema.Tasks", "AdminUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("nameofschema.Final Comments", "UserID", "dbo.AspNetUsers");
            DropForeignKey("nameofschema.Final Comments", "ProjectID", "nameofschema.Projects");
            DropForeignKey("nameofschema.Projects", "CategoryID", "nameofschema.Categories");
            DropForeignKey("nameofschema.Final Comments", "AdminUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("nameofschema.TasksDone", new[] { "ProjectID" });
            DropIndex("nameofschema.TasksDone", new[] { "UserID" });
            DropIndex("nameofschema.TasksDone", new[] { "AdminUserId" });
            DropIndex("nameofschema.Tasks", new[] { "ProjectID" });
            DropIndex("nameofschema.Tasks", new[] { "UserID" });
            DropIndex("nameofschema.Tasks", new[] { "AdminUserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("nameofschema.Projects", new[] { "CategoryID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("nameofschema.Final Comments", new[] { "ProjectID" });
            DropIndex("nameofschema.Final Comments", new[] { "UserID" });
            DropIndex("nameofschema.Final Comments", new[] { "AdminUserId" });
            DropTable("nameofschema.TasksDone");
            DropTable("nameofschema.Tasks");
            DropTable("dbo.AspNetRoles");
            DropTable("nameofschema.Projects");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("nameofschema.Final Comments");
            DropTable("nameofschema.Categories");
        }
    }
}
