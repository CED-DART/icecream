using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using IceCream.Data.Models;
using IceCream.Data.Repository;
using System;

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

        public void Update(User originalEntity, User user)
        {
            if (!string.IsNullOrEmpty(user.Name) && user.Name != originalEntity.Name)
                originalEntity.Name = user.Name;
            
            if (!string.IsNullOrEmpty(user.Email) && user.Email != originalEntity.Email)
                originalEntity.Email = user.Email;

            if (!string.IsNullOrEmpty(user.Contact) && user.Contact != originalEntity.Contact)
                originalEntity.Contact = user.Contact;

            if (user.BirthDate != null && user.BirthDate != originalEntity.BirthDate)
                originalEntity.BirthDate = user.BirthDate;

            if (user.AdmissionDate != null && user.AdmissionDate != originalEntity.AdmissionDate)
                originalEntity.AdmissionDate = user.AdmissionDate;

            if (!string.IsNullOrEmpty(user.Password))
                originalEntity.Password = GetMd5Hash(user.Password);

            if (user.ImageURL != originalEntity.ImageURL)
                originalEntity.ImageURL = user.ImageURL;

            if (user.IsAdmin != originalEntity.IsAdmin)
                originalEntity.IsAdmin = user.IsAdmin;

            UserRepository.Update(originalEntity);
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

        public void AcceptedTerms(User user)
        {
            if (user.AcceptedTemsDate == null)
            {
                user.AcceptedTemsDate = System.DateTime.Now;
            }
            UserRepository.Update(user);
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

        public List<User> GetUserWithAcceptance()
        {
            return UserRepository.GetUserWithAcceptance();
        }

        public bool ChangePassword(User entity, RequestChangePassword user)
        {
            if (entity.Password != GetMd5Hash(user.Password)) 
            {
                return false;
            }

            entity.Password = GetMd5Hash(user.NewPassword);

            UserRepository.Update(entity);

            return true;
        }

        public bool ResetPassword(User user)
        {  
            var token = new StringBuilder();

            //Prepare a 10-character random text
            //using (RNGCryptoServiceProvider
            //                    rngCsp = new RNGCryptoServiceProvider())
            //{
            //    var data = new byte[4];
            //    for (int i = 0; i < 10; i++)
            //    {
            //        //filled with an array of random numbers
            //        rngCsp.GetBytes(data);
            //        //this is converted into a character from A to Z
            //        var randomchar = Convert.ToChar(
            //                                  //produce a random number 
            //                                  //between 0 and 25
            //                                  BitConverter.ToUInt32(data, 0) % 26
            //                                  //Convert.ToInt32('A')==65
            //                                  + 65
            //                         );
            //        token.Append(randomchar);
            //    }
            //}
            ////This will be the password change identifier 
            ////that the user will be sent out
            //var tokenid = token.ToString();

            return true;
        }

        public void EnableDisable(User user, bool active)
        {
            user.Active = active;

            UserRepository.Update(user);
        }       
    }
}