namespace ClientApp.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string? Todo { get; set; }
        public bool IsComplete { get; set; }
    }
}
