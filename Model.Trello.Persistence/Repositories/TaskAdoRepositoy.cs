
using Model.Trello.Domain.Entities;
using Model.Trello.Domain.Entities.Enun;
using Model.Trello.Domain.Interface;
using Npgsql;
using System.Data;

namespace Model.Trello.Persistence.Repositories
{
    public class TaskAdoRepositoy : ITaskAdoRepositoy
    {
        private readonly IDbConnection _connection;

        public TaskAdoRepositoy(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<TaskEntity> Create(TaskEntity entity)
        {
            string commandText = "INSERT INTO tab_tasks " +
                                    @"(""Name"", ""DateCreated"", ""Status"") " +
                                    "VALUES " +
                                    "(@Name, @DateCreated, @Status) " +
                                    @"RETURNING ""Id"";";
            using var cmd = (NpgsqlCommand)_connection.CreateCommand();

            cmd.CommandText = commandText;

            cmd.Parameters.AddWithValue("@Name", entity.Name);
            cmd.Parameters.AddWithValue("@DateCreated", entity.DateCreated);
            cmd.Parameters.AddWithValue("@Status", (int)entity.Status);

            var result = await cmd.ExecuteScalarAsync();

            if(result != DBNull.Value)
            {
                entity.Id = (int)result;
            }

            return entity;

        }

        public async Task<List<TaskEntity>> GetAll()
        {
            string commandText = @"SELECT * FROM tab_tasks ORDER BY ""Id"" ASC;";
            using var cmd = (NpgsqlCommand)_connection.CreateCommand();
            cmd.CommandText = commandText;

            var reader = await cmd.ExecuteReaderAsync();

            var list = new List<TaskEntity>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    list.Add(new TaskEntity
                    {
                        DateCreated = (DateTime)reader["DateCreated"],
                        Id = (int)reader["id"],
                        Name = reader["name"].ToString(),
                        Status = (EStatusTask)reader["Status"],
                    });
                }
            }

            return list;
        }

        public async Task<TaskEntity> GetById(int id)
        {
            var commandText = @"SELECT * FROM ""tab_tasks"" " +
                                @"WHERE ""Id"" = "+
                                "@Id;";

            using var cmd = (NpgsqlCommand)_connection.CreateCommand();

            cmd.CommandText = commandText;
            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = await cmd.ExecuteReaderAsync();

            if (!reader.HasRows) return null;

            var taskEntity = new TaskEntity();
            while (reader.Read())
            {
                taskEntity.Name = reader["Name"].ToString();
                taskEntity.DateCreated = (DateTime)reader["DateCreated"];
                taskEntity.DateUpdated = reader.IsDBNull(reader.GetOrdinal("DateUpdated")) ? null : reader.GetDateTime(reader.GetOrdinal("DateUpdated"));
                taskEntity.Status = (EStatusTask)reader["Status"];
                taskEntity.Id = (int)reader["Id"];
            }

            return taskEntity;

        }

        public async Task <TaskEntity> UpdateForDelayed(int taskId)
        {
            return await UpdateTaskStatus(taskId, (int)EStatusTask.DELAYED);
        }
        public async Task<TaskEntity> UpdateForEnd(int taskId)
        {
            return await UpdateTaskStatus(taskId, (int)EStatusTask.END);

        }
        public async Task<TaskEntity> UpdateForInProcess(int taskId)
        {
            return await UpdateTaskStatus(taskId, (int)EStatusTask.IN_PROCESS);

        }

        private async Task<TaskEntity> UpdateTaskStatus(int taskId ,int status)
        {
            var commandText = @"UPDATE ""tab_tasks"" SET " +
                                @"""Status"" = " +
                                "@Status, " +
                                @"""DateUpdated"" =" +
                                "@DateUpdated WHERE " +
                                @"""Id"" = " + 
                                "@Id " +
                                @"RETURNING ""Id"", ""DateCreated"" , ""DateUpdated"", ""Name"" ,""Status"";";

            using var cmd = (NpgsqlCommand) _connection.CreateCommand();
            cmd.CommandText = commandText;

            cmd.Parameters.AddWithValue("@Status", status);
            cmd.Parameters.AddWithValue("@Id", taskId);
            cmd.Parameters.AddWithValue("@DateUpdated", DateTime.UtcNow);


            var reader = await cmd.ExecuteReaderAsync();

            var taskEntity = new TaskEntity();

            if (reader.HasRows)
            {
                await reader.ReadAsync();
                taskEntity.Id = reader.GetInt32(0);
                taskEntity.DateCreated = reader.GetDateTime(1);
                taskEntity.DateUpdated = reader.GetDateTime(2);
                taskEntity.Name = reader.GetString(3);
                taskEntity.Status = (EStatusTask)reader["Status"];
            }

            reader.Close();

            return taskEntity;

        }
    }
}
