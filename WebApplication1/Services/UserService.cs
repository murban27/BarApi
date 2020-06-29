using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IUserService
    {
        Task<Login> Authenticate(string username, string password);

    }

    public class UserService : IUserService
    {
        private restaurantvspjContext context = new restaurantvspjContext();



        public async Task<Login> Authenticate(string username, string password)
        {
            var user = await Task.Run(() => context.Login.SingleOrDefault(x => x.Login1 == username && x.Password == password));

            // Vrací NULL pokut uživatel neexistuje
            if (user == null)
                return null;

           
            user.Password = null;
            return user;
        }


    }
}