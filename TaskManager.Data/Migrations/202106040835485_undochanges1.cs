namespace TaskManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class undochanges1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FilePaths", "choreId", "dbo.Chores");
            DropIndex("dbo.FilePaths", new[] { "choreId" });
            RenameColumn(table: "dbo.FilePaths", name: "choreId", newName: "Chore_Id");
            AlterColumn("dbo.FilePaths", "Chore_Id", c => c.Int());
            CreateIndex("dbo.FilePaths", "Chore_Id");
            AddForeignKey("dbo.FilePaths", "Chore_Id", "dbo.Chores", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FilePaths", "Chore_Id", "dbo.Chores");
            DropIndex("dbo.FilePaths", new[] { "Chore_Id" });
            AlterColumn("dbo.FilePaths", "Chore_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.FilePaths", name: "Chore_Id", newName: "choreId");
            CreateIndex("dbo.FilePaths", "choreId");
            AddForeignKey("dbo.FilePaths", "choreId", "dbo.Chores", "Id", cascadeDelete: true);
        }
    }
}
