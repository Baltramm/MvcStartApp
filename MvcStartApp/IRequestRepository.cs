using MvcStartApp.Models.Db;
using System.Threading.Tasks;

namespace MvcStartApp
{
    public interface IRequestRepository
    {
        Task AddRequest(Request request);
    }
}
