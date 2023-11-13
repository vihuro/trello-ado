using FluentMigrator.Builders.Create.Table;


namespace Model.Trello.Persistence.Migrations
{
    public static class BaseVersion
    {
        public static ICreateTableColumnOptionOrWithColumnSyntax CreateBaseColumn
                                                            (ICreateTableWithColumnOrSchemaOrDescriptionSyntax column)
        {
            return column
                .WithColumn("Id")
                    .AsInt32()
                    .PrimaryKey()
                    .Identity()
                .WithColumn("DateCreated")
                    .AsDateTime()
                    .NotNullable()
                .WithColumn("DateUpdated")
                    .AsDateTime()
                    .Nullable();
        }
    }
}
