using FluentMigrator;


namespace Model.Trello.Persistence.Migrations
{
    [Migration((long)EVersions.CREATE_TASK_LIST, "Create tasks list")]
    public class Migrations0003CreateListOfTasks : Migration
    {
        public override void Up()
        {
            Create.Table("tab_list_tasks")
                .WithColumn("Id")
                    .AsInt32()
                    .PrimaryKey()
                    .Identity()

                .WithColumn("Name")
                    .AsString(50)
                    .NotNullable();



        }
        public override void Down()
        {
            Delete.Table("tab_list_of_tasks");
        }


    }
}
