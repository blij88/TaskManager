namespace TaskManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFiles3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Files", "chore_Id", "dbo.Chores");
            DropIndex("dbo.Files", new[] { "chore_Id" });
            AlterColumn("dbo.Files", "chore_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Files", "chore_Id");
            AddForeignKey("dbo.Files", "chore_Id", "dbo.Chores", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Files", "chore_Id", "dbo.Chores");
            DropIndex("dbo.Files", new[] { "chore_Id" });
            AlterColumn("dbo.Files", "chore_Id", c => c.Int());
            CreateIndex("dbo.Files", "chore_Id");
            AddForeignKey("dbo.Files", "chore_Id", "dbo.Chores", "Id");
        }
    }
}
