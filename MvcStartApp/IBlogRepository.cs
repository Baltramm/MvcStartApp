using MvcStartApp.Models.Db;
using System.Threading.Tasks;

namespace MvcStartApp
{
    public interface IBlogRepository
    {
        Task<User[]> GetUsers();
        Task AddUser(User user);
    }
}
