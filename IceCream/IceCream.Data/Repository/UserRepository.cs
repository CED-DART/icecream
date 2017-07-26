
using System.Collections.Generic;
using System.Linq;
using IceCream.Data.Context;
using IceCream.Data.Models;

namespace IceCream.Data.Repository
{
    public class UserRepository
    {
        public List<User> GetAllUser() 
        {
            List<User> response = new List<User>();

            using (IceCreamManagementContext repository = new IceCreamManagementContext()) 
            {
                response = repository.User.ToList();
            }

            return response;
        }
    }
}