using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShgEcom.Api.Middlerware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RequestResponseLoggingMiddleware(RequestDelegate next)
    {
        public async Task Invoke(HttpContext context)
        {
            //Log Request
            var requestLog = await FormatRequest(context.Request);
            LogToFile(requestLog);

            //Log Response
            var originalBodyStream = context.Response.Body;
            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            await next(context);

            var responseLog = await FormatResponse(context.Response);
            LogToFile(responseLog);

            await responseBody.CopyToAsync(originalBodyStream);
        }

        private static async Task<string> FormatRequest(HttpRequest request)
        {
            request.EnableBuffering();
            var body = await new StreamReader(request.Body, Encoding.UTF8).ReadToEndAsync();
            request.Body.Position = 0;

            return $"REQUEST: {request.Method} {request.Path} \nHeaders: {string.Join(", ", request.Headers)} \nBody: {body}\n";
        }

        private static async Task<string> FormatResponse(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            var body = await new StreamReader(response.Body, Encoding.UTF8).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            return $"RESPONSE: {response.StatusCode} \nBody: {body}\n";
        }

        private static void LogToFile(string log)
        {
            string logFilePath = "logs/api_logs.txt";
            Directory.CreateDirectory(Path.GetDirectoryName(logFilePath)!);
            File.AppendAllText(logFilePath, $"{DateTime.UtcNow} - {log}\n\n");
        }
    }
}
