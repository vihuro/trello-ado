
using Model.Trello.Domain.Entities;
using Model.Trello.Domain.Interface;
using Npgsql;
using System.Data;

namespace Model.Trello.Persistence.Repositories
{
    public class TaskInListDAORepository : ITaskInListDAORepository
    {
        private readonly IDbConnection _connection;

        public TaskInListDAORepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task InsertTaskInList(int TaskId, int ListId)
        {

            string commandText = "INSERT INTO tab_task_in_list " +
                                    @"(""TaskId"" , ""LisTaskId"",""Order"") " +
                                    "VALUES " +
                                    "(@TaskId, @ListId,@Order);";

            var valueRow = await AccounRow(ListId);


            using var cmd = (NpgsqlCommand)_connection.CreateCommand();
            cmd.CommandText = commandText;

            cmd.Parameters.AddWithValue("@TaskId", TaskId);
            cmd.Parameters.AddWithValue("ListId", ListId);
            cmd.Parameters.AddWithValue("@Order", valueRow + 1);
            try
            {

                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public async Task<int> AccounRow(int ListId)
        {
            string commandTextAccount = "SELECT COUNT(*) FROM tab_task_in_list WHERE " +
                                        @"""LisTaskId"" = " +
                                        "@ListId";
            var cmd = (NpgsqlCommand)_connection.CreateCommand();
            cmd.CommandText = commandTextAccount;
            cmd.Parameters.AddWithValue("@ListId", ListId);
            try
            {
                var reader = await cmd.ExecuteScalarAsync();


                var count = await cmd.ExecuteScalarAsync();
                cmd.Dispose();
                if (count != DBNull.Value)
                {
                    return Convert.ToInt32(count);
                }
                throw new Exception("Erro ao obter a contagem de linhas.");

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }

        }

        public async Task<TaskInListEntity> GetById(int TaskId)
        {
            string commandText = "SELECT * FROM tab_task_in_list WHERE \"TaskId\" = @TaskId";

            using var cmd = (NpgsqlCommand)_connection.CreateCommand();

            cmd.CommandText = commandText;

            cmd.Parameters.AddWithValue("@TaskId", TaskId);

            var reader = await cmd.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                var entity = new TaskInListEntity();
                while (reader.Read())
                {
                    entity.Id = (int)reader["Id"];
                    entity.Order = (int)reader["Order"];
                    entity.TaskListId = (int)reader["LisTaskId"];
                }
                return entity;
            }
            return null;
        }

        private async Task<List<TaskInListEntity>> GetByListTaskId(int ListTaskId)
        {
            var items = new List<TaskInListEntity>();
            string selectQuery = "SELECT * FROM tab_task_in_list WHERE \"LisTaskId\" = @ListTaskId;";
            using (var selectCmd = (NpgsqlCommand)_connection.CreateCommand())
            {
                selectCmd.CommandText = selectQuery;
                selectCmd.Parameters.AddWithValue("@ListTaskId", ListTaskId);


                using (var reader = await selectCmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        // Mapeie os dados para objetos TaskInListEntity e adicione à lista
                        var item = new TaskInListEntity
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            TaskId = reader.GetInt32(reader.GetOrdinal("TaskId")),
                            TaskListId = reader.GetInt32(reader.GetOrdinal("LisTaskId")),
                            Order = reader.GetInt32(reader.GetOrdinal("Order"))
                        };
                        items.Add(item);
                    }
                }
            }

            return items;

        }

        public async Task<TaskInListEntity> UpdatePostion(int TaskId, int Position, int ListTaskId)
        {
            var items = await GetByListTaskId(ListTaskId);

            items = items.OrderBy(item => item.Order).ToList();

            var sortedItems = items.OrderBy(item => item.Order).ToList();

            var oneItem = sortedItems.FirstOrDefault(x => x.TaskId == TaskId);

            sortedItems.Remove(oneItem);

            sortedItems = sortedItems.OrderBy(x => x.Order).ToList();


            for (int i = 0; i < sortedItems.Count; i++)
            {
                if (i + 1 == Position || i + 1 > Position)
                {
                    sortedItems[i].Order = i + 2;
                }
                else
                {
                    sortedItems[i].Order = i + 1;

                }
            }
            oneItem.Order = Position;
            sortedItems.Add(oneItem);

            await Update(sortedItems);

            return null;

        }

        private async Task Update(List<TaskInListEntity> sortedItems)
        {
            string updateQuery = "UPDATE tab_task_in_list SET \"Order\" = @Order WHERE \"Id\" = @ItemId;";


            foreach (var item in sortedItems)
            {
                using var updateCmd = (NpgsqlCommand)_connection.CreateCommand();
                updateCmd.CommandText = updateQuery;

                updateCmd.Parameters.AddWithValue("@Order", item.Order);
                updateCmd.Parameters.AddWithValue("@ItemId", item.Id);

                await updateCmd.ExecuteNonQueryAsync();

                updateCmd.Parameters.Clear();

            }
        }
    }
}
