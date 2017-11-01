using System;
using System.Collections.Generic;
using System.Linq;
using IceCream.Data.Models;

namespace IceCream.Data.Repository
{
    public class UserRepository
    {
        private DBIceScreamContext Context { get; set; }

        public UserRepository(DBIceScreamContext context)
        {
            Context = context;
        }

        public List<User> GetAllUser()
        {
            List<User> response = new List<User>();

            response = Context.User.ToList();

            return response;
        }

        public User Get(int id)
        {
            User user = new User();

            user = Context.User.FirstOrDefault(u => u.IdUser == id);

            return user;
        }

        public void Add(User user)
        {
            user.Created = DateTime.Now;
            Context.User.Add(user);

            Context.SaveChanges();
        }

        public void Update(User user)
        {
            User entity = Context.User.FirstOrDefault(u => u.IdUser == user.IdUser);

            if (entity != null)
            {
                entity.AcceptedTemsDate = user.AcceptedTemsDate;
                entity.AdmissionDate = user.AdmissionDate;
                entity.BirthDate = user.BirthDate;
                entity.Contact = user.Contact;
                entity.Email = user.Email;
                entity.Name = user.Name;
                entity.Password = user.Password;
                entity.IsAdmin = user.IsAdmin;
                entity.Active = user.Active;
                
                Context.User.Update(entity);

                Context.SaveChanges();
            }
        }

        public void Delete(int Id)
        {
            User user = Context.User.FirstOrDefault(u => u.IdUser == Id);

            Context.User.Remove(user);
            Context.SaveChanges();
        }

        public User GetByLogin(string email, string password)
        {
            User user = Context.User.FirstOrDefault(u => u.Email == email && u.Password == password);

            return user;
        }

        public List<User> GetUserWithAcceptance()
        {
            var response = Context.User.Where(u => u.AcceptedTemsDate != null).ToList();

            return response;
        }

        public User GetByToken(string token)
        {
            User user = Context.User.FirstOrDefault(u => u.Token == token);

            return user;
        }

        public User GetByEmail(string email)
        {
            User user = Context.User.FirstOrDefault(u => u.Email == email);

            return user;
        }

    }
}