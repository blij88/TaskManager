namespace TaskManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFil2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Files", name: "task_Id", newName: "chore_Id");
            RenameIndex(table: "dbo.Files", name: "IX_task_Id", newName: "IX_chore_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Files", name: "IX_chore_Id", newName: "IX_task_Id");
            RenameColumn(table: "dbo.Files", name: "chore_Id", newName: "task_Id");
        }
    }
}
