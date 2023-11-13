using FluentMigrator;
using System.Data;

namespace Model.Trello.Persistence.Migrations
{
    [Migration((long)EVersions.CREATE_TASKS_IN_LIST, "Create tasks in list")]
    public class _0004CreateListOfTasks : Migration
    {
        public override void Up()
        {
            Create.Table("tab_task_in_list")
                 .WithColumn("Id")
                    .AsInt32()
                    .PrimaryKey()
                    .Identity()
                  .WithColumn("Order")
                    .AsInt32()
                    .NotNullable()

                .WithColumn("TaskId")
                    .AsInt32()
                    .WithColumn("LisTaskId")
                    .AsInt32();

            Create.ForeignKey()
                .FromTable("tab_task_in_list")
                .ForeignColumn("TaskId")
                .ToTable("tab_tasks")
                .PrimaryColumn("Id")
                .OnDelete(Rule.Cascade);

            Create.ForeignKey()
                .FromTable("tab_task_in_list")
                .ForeignColumn("LisTaskId")
                .ToTable("tab_list_tasks")
                .PrimaryColumn("Id")
                .OnDelete(Rule.Cascade);
        }
        public override void Down()
        {
            Delete.Table("tab_task_in_list");
        }


    }
}
