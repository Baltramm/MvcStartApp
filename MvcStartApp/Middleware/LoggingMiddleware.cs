using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using MvcStartApp.Models.Db;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MvcStartApp.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IRequestRepository _repo;
        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware(RequestDelegate next, IRequestRepository repo)
        {
            _next = next;
            _repo = repo;
        }

        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            // Для логирования данных о запросе используем свойста объекта HttpContext
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");
            // Добавим создание нового пользователя
            var newRequest = new Request()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Url = $"http://{context.Request.Host.Value + context.Request.Path}"
            };
            await _repo.AddRequest(newRequest);
            // Передача запроса далее по конвейеру
            await _next.Invoke(context);
            
        }
    }
}
