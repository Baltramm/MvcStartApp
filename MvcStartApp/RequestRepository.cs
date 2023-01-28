using Microsoft.EntityFrameworkCore;
using MvcStartApp.Models.Db;
using System.Threading.Tasks;

namespace MvcStartApp
{
    public class RequestRepository:IRequestRepository
    {
        // ссылка на контекст
        private readonly RequestContext _context;

        // Метод-конструктор для инициализации
        public RequestRepository(RequestContext context)
        {
            _context = context;
        }

        public async Task AddRequest(Request request)
        {
            // Добавление запроса
            var entry = _context.Entry(request);
            if (entry.State == EntityState.Detached)
                await _context.Requests.AddAsync(request);

            // Сохранение изенений
            await _context.SaveChangesAsync();
        }
        public async Task<Request[]> GetRequests()
        {
            // Получим все запросы
            return await _context.Requests.ToArrayAsync();
        }
    }
}
