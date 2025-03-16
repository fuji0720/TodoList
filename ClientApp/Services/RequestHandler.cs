using Microsoft.AspNetCore.Mvc;

namespace ClientApp.Services
{
    public static class RequestHandler
    {
        public static async Task<string> Request(TodoClient client, HttpRequestMessage request)
        {
            HttpResponseMessage response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
        }
    }
}
