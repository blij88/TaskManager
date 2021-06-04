namespace TaskManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FilePaths",
                c => new
                    {
                        FilePathId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        PersonID = c.Int(nullable: false),
                        chore_Id = c.Int(),
                    })
                .PrimaryKey(t => t.FilePathId)
                .ForeignKey("dbo.Chores", t => t.chore_Id)
                .Index(t => t.chore_Id);
            
            CreateTable(
                "dbo.Chores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Description = c.String(maxLength: 500),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Progress = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PeopleWhoCanHelps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        ContactInfo = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FilePaths", "chore_Id", "dbo.Chores");
            DropIndex("dbo.FilePaths", new[] { "chore_Id" });
            DropTable("dbo.PeopleWhoCanHelps");
            DropTable("dbo.Chores");
            DropTable("dbo.FilePaths");
        }
    }
}
