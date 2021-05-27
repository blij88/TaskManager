namespace TaskManager.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddedContacts : DbMigration
    {
        public override void Up()
        {
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
            DropTable("dbo.PeopleWhoCanHelps");
        }
    }
}
