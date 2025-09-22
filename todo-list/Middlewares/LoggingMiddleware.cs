using System.Diagnostics;
using System.Threading.Tasks;
using todo_list.Models;
using todo_list.Services;

namespace todo_list.Middlewares
{
	public class LoggingMiddleware
	{
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            var metodo = context.Request.Method;
            var caminho = context.Request.Path;
            var enderecoIp = context.Connection.RemoteIpAddress?.ToString() ?? "Desconhecido";

            await _next(context); 

            stopwatch.Stop();

            var status = context.Response.StatusCode.ToString();
            var tempoExecucaoMs = stopwatch.Elapsed.TotalMilliseconds;

            LogService.AdicionarLog(new LogModel
            {
                MetodoHttp = metodo,
                Caminho = caminho,
                EnderecoIp = enderecoIp,
                Status = status,
                TempoExecucaoMs = tempoExecucaoMs
            });
        }
    

    }
}

