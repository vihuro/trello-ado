using Model.Trello.Domain.Entities;
using Model.Trello.Domain.Interface;
using Npgsql;
using System.Data;

namespace Model.Trello.Persistence.Repositories
{
    public class ListTasksDAORepository : IListTasksDAORepository
    {
        private readonly IDbConnection _connection;

        public ListTasksDAORepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<ListTasksEntity> CreateTaskList(string Name)
        {
            var commandText = @"INSERT INTO tab_list_tasks (""Name"") VALUES " +
                               "(@Name);";

            using var cmd = (NpgsqlCommand)_connection.CreateCommand();
            cmd.CommandText = commandText;

            cmd.Parameters.AddWithValue("@Name", Name);



            await cmd.ExecuteScalarAsync(); 


            return new ListTasksEntity();
        }

        public async Task<List<ListTasksEntity>> GetList()
        {

            var commandText = "SELECT " +
                "tab_list_tasks.\"Id\" AS \"ListId\", " +
                "tab_list_tasks.\"Name\" AS \"ListName\" " +
                "FROM tab_list_tasks " +
                "INNER JOIN tab_task_in_list ON tab_task_in_list.\"LisTaskId\" = tab_list_tasks.\"Id\" " + 
                "INNER JOIN tab_tasks ON tab_tasks.\"Id\" = tab_task_in_list.\"TaskId\";";

            var commandText2 = "SELECT " +
                "tab_list_tasks.\"Id\" AS \"ListId\", " +
                "tab_list_tasks.\"Name\" AS \"ListName\"," +
                "tab_task_in_list.\"Id\" AS \"TaskInListId\", " +
                "tab_task_in_list.\"Order\", " +
                "tab_tasks.\"Id\" AS \"TaskId\", " +
                "tab_tasks.\"Name\" AS \"TaskName\" " +
                "FROM tab_list_tasks " +
                "INNER JOIN tab_task_in_list " +
                "ON tab_task_in_list.\"LisTaskId\" = tab_list_tasks.\"Id\" " +
                "INNER JOIN tab_tasks " +
                "ON tab_tasks.\"Id\" = tab_task_in_list.\"TaskId\";";

            using var cmd = (NpgsqlCommand)_connection.CreateCommand();

            cmd.CommandText = commandText2;

            var reader = await cmd.ExecuteReaderAsync();


            var listTasks = new List<ListTasksEntity>();
            ListTasksEntity currentList = null;

            while (reader.Read())
            {
                int listId = reader.GetInt32(reader.GetOrdinal("ListId"));

                if (currentList == null || currentList.Id != listId)
                {
                    currentList = new ListTasksEntity
                    {
                        Id = listId,
                        Name = reader.GetString(reader.GetOrdinal("ListName")),
                        List = new List<TaskInListEntity>()
                    };

                    listTasks.Add(currentList);
                }

                var taskInList = new TaskInListEntity
                {
                    Task = new TaskEntity
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("TaskId")),
                        Name = reader.GetString(reader.GetOrdinal("TaskName"))
                    },
                    Order = reader.GetInt32(reader.GetOrdinal("Order"))
                };

               currentList.List.Add(taskInList);
            }

            return listTasks;
        }
    }
}
