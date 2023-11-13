using FluentMigrator;

namespace Model.Trello.Persistence.Migrations
{
    [Migration((long)EVersions.CREATE_TABLE_TASK, "Create table TASK")]
    public class _0002CreateTableTask : Migration
    {


        public override void Up()
        {
            var table = BaseVersion.CreateBaseColumn(Create.Table("tab_tasks"));

            table.WithColumn("Name")
                    .AsString(50)
                    .NotNullable()
                .WithColumn("Status")
                .AsInt32()
                .NotNullable();
        }
        public override void Down()
        {
            Delete.Table("tab_task");

        }
    }
}
