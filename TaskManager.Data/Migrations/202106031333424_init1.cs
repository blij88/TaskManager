namespace TaskManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.FilePaths", new[] { "chore_Id" });
            CreateIndex("dbo.FilePaths", "Chore_Id");
            DropColumn("dbo.FilePaths", "PersonID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FilePaths", "PersonID", c => c.Int(nullable: false));
            DropIndex("dbo.FilePaths", new[] { "Chore_Id" });
            CreateIndex("dbo.FilePaths", "chore_Id");
        }
    }
}
