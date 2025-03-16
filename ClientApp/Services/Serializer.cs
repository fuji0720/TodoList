using System.Text.Json;
using ClientApp.Models;

namespace ClientApp.Services
{
    public static class Serializer
    {
        public static string SerializeFromObject(TodoItem todoItem)
        {
            string message = JsonSerializer.Serialize<TodoItem>(todoItem);
            return message;
        }

        public static TodoItem DeserializeToObject(string responseBody)
        {
            TodoItem item = JsonSerializer.Deserialize<TodoItem>(responseBody)!;
            return item;
        }

        public static List<TodoItem> DeserializeToList(string responseBody)
        {
            List<TodoItem> list = JsonSerializer.Deserialize<List<TodoItem>>(responseBody)!;
            return list;
        }
    }
}
