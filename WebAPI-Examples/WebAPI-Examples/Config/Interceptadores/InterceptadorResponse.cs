using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace WebAPI_Examples.Config.Interceptadores
{
    public class InterceptadorResponse
    {
        private readonly RequestDelegate _next;

        public InterceptadorResponse(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            using (var buffer = new MemoryStream())
            {
                var stream = context.Response.Body;
                context.Response.Body = buffer;
                await _next.Invoke(context);
                buffer.Seek(0, SeekOrigin.Begin);
                var reader = new StreamReader(buffer);
                using (var bufferReader = new StreamReader(buffer))
                {
                    string body = await bufferReader.ReadToEndAsync();
                    var produto = new
                    {
                        link = "https://minhaapi.com.br",
                        data = await ObterResposta(context.Response)
                    };
                    var jsonString = JsonConvert.SerializeObject(produto);
                    await context.Response.WriteAsync(jsonString);
                    context.Response.Body.Seek(0, SeekOrigin.Begin);
                    context.Response.Body.CopyTo(stream);
                    context.Response.Body = stream;
                }
            }
        }

        private async Task<object> ObterResposta(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            string textStream = await new StreamReader(response.Body).ReadToEndAsync();
            var objeto = !string.IsNullOrEmpty(textStream) ? JsonConvert.DeserializeObject(textStream) : null;
            response.Body.Seek(0, SeekOrigin.Begin);
            return objeto;
        }
    }
}

