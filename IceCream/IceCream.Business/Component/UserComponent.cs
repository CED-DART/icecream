
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
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
            user.Password = GetMd5Hash(user.Password);
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

        public User Login(string email, string password)
        {
            User user = new User();

            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                password = GetMd5Hash(password);

                user = UserRepository.GetByLogin(email, password);
            }

            return user;
        }

        private string GetMd5Hash(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder response = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    response.Append(data[i].ToString("x2"));
                }
    
                return response.ToString();
            }
        }

    }
}