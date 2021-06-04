namespace TaskManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FileChanges1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FilePaths", "Chore_Id", "dbo.Chores");
            DropIndex("dbo.FilePaths", new[] { "Chore_Id" });
            RenameColumn(table: "dbo.FilePaths", name: "Chore_Id", newName: "choreId");
            AlterColumn("dbo.FilePaths", "choreId", c => c.Int(nullable: false));
            CreateIndex("dbo.FilePaths", "choreId");
            AddForeignKey("dbo.FilePaths", "choreId", "dbo.Chores", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FilePaths", "choreId", "dbo.Chores");
            DropIndex("dbo.FilePaths", new[] { "choreId" });
            AlterColumn("dbo.FilePaths", "choreId", c => c.Int());
            RenameColumn(table: "dbo.FilePaths", name: "choreId", newName: "Chore_Id");
            CreateIndex("dbo.FilePaths", "Chore_Id");
            AddForeignKey("dbo.FilePaths", "Chore_Id", "dbo.Chores", "Id");
        }
    }
}
