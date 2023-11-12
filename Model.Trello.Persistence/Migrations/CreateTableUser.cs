using FluentMigrator;

namespace Model.Trello.Persistence.Migrations
{
    public class CreateTableUser : Migration
    {
        public override void Up()
        {
            Create.Table("tab_user")
                .WithColumn("Id")
                    .AsInt64()
                    .PrimaryKey()
                .WithColumn("Name")
                    .AsString()
                    .NotNullable();

        }
        public override void Down()
        {
            Delete.Table("tab_user");
        }
    }
}
