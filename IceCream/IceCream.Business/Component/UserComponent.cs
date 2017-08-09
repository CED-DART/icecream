
using System.Collections.Generic;
using IceCream.Data.Models;
using IceCream.Data.Repository;

namespace IceCream.Business.Component 
{
    public class UserComponent 
    {
        private UserRepository UserRepository { get; set; }

        public UserComponent(IceCreamManagementContext context)
        {
            UserRepository = new UserRepository(context);
        }

        public List<User> GetAll() 
        {
            return UserRepository.GetAllUser();
        }

        public User Get(int id)
        {
            return UserRepository.Get(id);
        }

        public void Add(User user)
        {
            UserRepository.Add(user);
        }

        public void Update(User user)
        {
            UserRepository.Update(user);
        }

        public void Delete(int id) 
        {
            UserRepository.Delete(id);
        }

    }
}