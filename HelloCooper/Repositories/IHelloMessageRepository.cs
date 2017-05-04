using System.Threading.Tasks;
using HelloCooper.Models;

namespace HelloCooper.Repositories
{
    public interface IHelloMessageRepository
    {
        Task<CustomMessage> GetCustomHelloMessageAsync(string messageId);
        Task CreateCustomHelloMessageAsync(CustomMessage customMessage);
    }
}