
using System.Collections.Generic;
using IceCream.Data.Models;
using IceCream.Data.Repository;

namespace IceCream.Business.Component 
{
    public class UserComponent 
    {
        public UserComponent()
        {
            UserRepository = new UserRepository();
        }

        private UserRepository UserRepository { get; set; }

        public List<User> GetAllUser(IceCreamManagementContext context) 
        {
            List<User> userList = UserRepository.GetAllUser(context);

            return userList;
        }

    }
}