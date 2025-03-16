using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly TodoDbContext _context;

        public TodoController(TodoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<TodoItem> todoItems = await _context.TodoItemDb.ToListAsync();
            string response = JsonSerializer.Serialize(todoItems);
            return Content(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] long id)
        {
            TodoItem? todoItem = await _context.TodoItemDb.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            string response = JsonSerializer.Serialize(todoItem);
            return Content(response);
            // return Ok(todoItem);
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            HttpRequest _request = Request;
            Stream requestBody = _request.Body;
            TodoItem todoItem = await JsonSerializer.DeserializeAsync<TodoItem>(requestBody)!;

            _context.TodoItemDb.Add(todoItem);
            await _context.SaveChangesAsync();
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] long id)
        {
            HttpRequest _request = Request;
            Stream requestBody = _request.Body;
            TodoItem putItem = await JsonSerializer.DeserializeAsync<TodoItem>(requestBody)!;

            TodoItem? todoItem = await _context.TodoItemDb.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            todoItem.Todo = putItem.Todo;
            todoItem.IsComplete = putItem.IsComplete;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            TodoItem? todoItem = await _context.TodoItemDb.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _context.TodoItemDb.Remove(todoItem);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
