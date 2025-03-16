using System.Text.Json;
using ClientApp.Models;

namespace ClientApp.Services
{
    public class TodoClient : HttpClient
    {
        public TodoClient()
        {
            BaseAddress = new Uri("****");
        }
    }
}
