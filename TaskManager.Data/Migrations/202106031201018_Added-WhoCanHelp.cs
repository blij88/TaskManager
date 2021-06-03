namespace TaskManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedWhoCanHelp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "WhoCanHelp_Id", c => c.Int());
            CreateIndex("dbo.Tasks", "WhoCanHelp_Id");
            AddForeignKey("dbo.Tasks", "WhoCanHelp_Id", "dbo.PeopleWhoCanHelps", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "WhoCanHelp_Id", "dbo.PeopleWhoCanHelps");
            DropIndex("dbo.Tasks", new[] { "WhoCanHelp_Id" });
            DropColumn("dbo.Tasks", "WhoCanHelp_Id");
        }
    }
}
