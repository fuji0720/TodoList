using Microsoft.AspNetCore.Mvc;
using ClientApp.Models;
using ClientApp.Services;

namespace ClientApp.Controllers
{
    public class TodoController : Controller
    {
        private readonly ILogger<TodoController> _logger;

        public TodoController(ILogger<TodoController> logger)
        {
            _logger = logger;
        }

        // GET: Todo
        public async Task<IActionResult> Index()
        {
            TodoClient client = new TodoClient();

            HttpMethod method = new HttpMethod("Get");
            string relativeUri = "/api/todo";
            Uri uri = new Uri(client.BaseAddress, relativeUri);

            HttpRequestMessage request = new HttpRequestMessage();
            request.Method = method;
            request.RequestUri = uri;

            string responseBody = await RequestHandler.Request(client, request);
            List<TodoItem> list = Serializer.DeserializeToList(responseBody)!;

            return View(list);
        }

        // GET: Todo/Details/5
        public async Task<IActionResult> Details(long id)
        {
            TodoClient client = new TodoClient();

            HttpMethod method = new HttpMethod("Get");
            string relativeUri = "/api/todo/" + id.ToString();
            Uri uri = new Uri(client.BaseAddress, relativeUri);

            HttpRequestMessage request = new HttpRequestMessage();
            request.Method = method;
            request.RequestUri = uri;

            string responseBody = await RequestHandler.Request(client, request);
            TodoItem item = Serializer.DeserializeToObject(responseBody)!;

            return View(item);
        }

        // GET: Todo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Todo/Create
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateResult(TodoItem todoItem)
        {
            try
            {
                TodoClient client = new TodoClient();

                HttpMethod method = new HttpMethod("Post");
                string relativeUri = "/api/todo";
                Uri uri = new Uri(client.BaseAddress, relativeUri);

                string message = Serializer.SerializeFromObject(todoItem)!;
                StringContent content = new StringContent(message);

                HttpRequestMessage request = new HttpRequestMessage();
                request.Method = method;
                request.RequestUri = uri;
                request.Content = content;

                string responseBody = await RequestHandler.Request(client, request);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Todo/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            TodoClient client = new TodoClient();

            HttpMethod method = new HttpMethod("Get");
            string relativeUri = "/api/todo/" + id.ToString();
            Uri uri = new Uri(client.BaseAddress, relativeUri);

            HttpRequestMessage request = new HttpRequestMessage();
            request.Method = method;
            request.RequestUri = uri;

            string responseBody = await RequestHandler.Request(client, request);
            TodoItem item = Serializer.DeserializeToObject(responseBody)!;

            return View(item);
        }

        // POST: Todo/Edit/5
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditResult(long id, TodoItem todoItem)
        {
            try
            {
                TodoClient client = new TodoClient();

                HttpMethod method = new HttpMethod("Put");
                string relativeUri = "/api/todo/" + id.ToString();
                Uri uri = new Uri(client.BaseAddress, relativeUri);

                string message = Serializer.SerializeFromObject(todoItem)!;
                StringContent content = new StringContent(message);

                HttpRequestMessage request = new HttpRequestMessage();
                request.Method = method;
                request.RequestUri = uri;
                request.Content = content;

                string responseBody = await RequestHandler.Request(client, request);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Todo/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            TodoClient client = new TodoClient();

            HttpMethod method = new HttpMethod("Get");
            string relativeUri = "/api/todo/" + id.ToString();
            Uri uri = new Uri(client.BaseAddress, relativeUri);

            HttpRequestMessage request = new HttpRequestMessage();
            request.Method = method;
            request.RequestUri = uri;

            string responseBody = await RequestHandler.Request(client, request);
            TodoItem item = Serializer.DeserializeToObject(responseBody)!;

            return View(item);
        }

        // POST: Todo/Delete/5
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteResult(long id)
        {
            try
            {
                TodoClient client = new TodoClient();

                HttpMethod method = new HttpMethod("Delete");
                string relativeUri = "/api/todo/" + id.ToString();
                Uri uri = new Uri(client.BaseAddress, relativeUri);

                HttpRequestMessage request = new HttpRequestMessage();
                request.Method = method;
                request.RequestUri = uri;

                string responseBody = await RequestHandler.Request(client, request);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
