using System.Threading.Tasks;
using Assignment_1_.Models;

namespace Assignment_1_.Data
{
    public interface IUserService
    {
        Task<User> validateUser(string userName, string Password);
    }
}