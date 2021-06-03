namespace TaskManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFile : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Tasks", newName: "Chores");
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        task_Id = c.Int(),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.Chores", t => t.task_Id)
                .Index(t => t.task_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Files", "task_Id", "dbo.Chores");
            DropIndex("dbo.Files", new[] { "task_Id" });
            DropTable("dbo.Files");
            RenameTable(name: "dbo.Chores", newName: "Tasks");
        }
    }
}
