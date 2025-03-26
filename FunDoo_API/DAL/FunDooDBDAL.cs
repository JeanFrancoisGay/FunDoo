using FunDoo_API.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;

namespace FunDoo_API.DAL
{
    public static class FunDooDBDAL
    {
        private static readonly string FunDoo_DB_ConnectionString;

        static FunDooDBDAL()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            FunDoo_DB_ConnectionString = configuration.GetConnectionString("FunDoo_DB");
        }

        internal static List<ToDoItemModel> GetAllItems()
        {
            using (var conn = new SqlConnection(FunDoo_DB_ConnectionString))
            using (var cmd = new SqlCommand("spTodoItem_Get", conn))
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                var items = new List<ToDoItemModel>();
                while (reader.Read())
                {
                    items.Add(new ToDoItemModel
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        Title = reader.GetString(reader.GetOrdinal("Title")),
                        Description = reader.GetString(reader.GetOrdinal("Description")),
                        DueDate = reader.GetDateTime(reader.GetOrdinal("DueDate")),
                        IsCompleted = reader.GetBoolean(reader.GetOrdinal("IsCompleted"))
                    });
                }
                return items;
            }
        }

        internal static ToDoItemModel? GetItem(int id)
        {
            using (var conn = new SqlConnection(FunDoo_DB_ConnectionString))
            using (var cmd = new SqlCommand("spTodoItem_Get", conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return new ToDoItemModel
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        Title = reader.GetString(reader.GetOrdinal("Title")),
                        Description = reader.GetString(reader.GetOrdinal("Description")),
                        DueDate = reader.GetDateTime(reader.GetOrdinal("DueDate")),
                        IsCompleted = reader.GetBoolean(reader.GetOrdinal("IsCompleted"))
                    };
                }
                return null;
            }
        }

        internal static void AddItem(ToDoItemModel item)
        {
            using (var conn = new SqlConnection(FunDoo_DB_ConnectionString))
            using (var cmd = new SqlCommand("spTodoItem_Insert", conn))
            {
                cmd.Parameters.AddWithValue("@Title", item.Title);
                cmd.Parameters.AddWithValue("@Description", item.Description);
                cmd.Parameters.AddWithValue("@DueDate", item.DueDate);
                cmd.Parameters.AddWithValue("@IsCompleted", item.IsCompleted);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        internal static void UpdateItem(ToDoItemModel item)
        {
            using (var conn = new SqlConnection(FunDoo_DB_ConnectionString))
            using (var cmd = new SqlCommand("spTodoItem_Update", conn))
            {
                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Title", item.Title);
                cmd.Parameters.AddWithValue("@Description", item.Description);
                cmd.Parameters.AddWithValue("@DueDate", item.DueDate);
                cmd.Parameters.AddWithValue("@IsCompleted", item.IsCompleted);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        internal static void DeleteItem(int id)
        {
            using (var conn = new SqlConnection(FunDoo_DB_ConnectionString))
            using (var cmd = new SqlCommand("spTodoItem_Delete", conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
