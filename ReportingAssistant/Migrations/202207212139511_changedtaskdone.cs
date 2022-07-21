namespace ReportingAssistant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedtaskdone : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Long(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.FinalComments",
                c => new
                    {
                        FinalCommentID = c.Long(nullable: false, identity: true),
                        Screen = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false),
                        AdminUserID = c.Long(nullable: false),
                        UserID = c.Long(nullable: false),
                        DateOfFinalComment = c.DateTime(nullable: false),
                        Attachment = c.String(),
                        ProjectID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.FinalCommentID);
            
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
                .PrimaryKey(t => t.ProjectID);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskID = c.Long(nullable: false, identity: true),
                        Screen = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false),
                        AdminUserID = c.Long(nullable: false),
                        UserID = c.Long(nullable: false),
                        DateOfTask = c.DateTime(nullable: false),
                        Attachment = c.String(),
                        ProjectID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.TaskID);
            
            CreateTable(
                "dbo.TaskDones",
                c => new
                    {
                        TaskDoneID = c.Long(nullable: false, identity: true),
                        Screen = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false),
                        AdminUserID = c.Long(nullable: false),
                        UserID = c.Long(nullable: false),
                        DateOfTaskDone = c.DateTime(nullable: false),
                        Attachment = c.String(),
                        ProjectID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.TaskDoneID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TaskDones");
            DropTable("dbo.Tasks");
            DropTable("nameofschema.Projects");
            DropTable("dbo.FinalComments");
            DropTable("dbo.Categories");
        }
    }
}
