
using System.Collections.Generic;
using System.Linq;
using IceCream.Data.Models;

namespace IceCream.Data.Repository
{
    public class UserRepository
    {
        public List<User> GetAllUser(IceCreamManagementContext context) 
        {
            List<User> response = new List<User>();

            response = context.User.ToList();

            return response;
        }
    }
}