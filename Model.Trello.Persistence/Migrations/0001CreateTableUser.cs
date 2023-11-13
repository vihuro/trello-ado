using FluentMigrator;

namespace Model.Trello.Persistence.Migrations
{
    [Migration((long)EVersions.CREATE_TABLE_USERS, "Create table Users")]
    public class CreateTableUser : Migration
    {
        public override void Up()
        {
            var table = BaseVersion.CreateBaseColumn(Create.Table("tab_users"));

            table.WithColumn("Name")
                    .AsString(100)
                    .NotNullable()
                  .WithColumn("Password")
                  .AsString(300)
                  .NotNullable();

        }
        public override void Down()
        {
            Delete.Table("tab_user");
        }
    }
}
