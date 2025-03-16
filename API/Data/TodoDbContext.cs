using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItemDb { get; set; } = null!;
    }
}
