using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using IceCream.Data.Models;
using IceCream.Data.Repository;
using System;
using System.Net;
using System.IO;
using System.Net.Http;

namespace IceCream.Business.Component
{
    public class UserComponent
    {
        private UserRepository UserRepository { get; set; }

        public UserComponent(DBIceScreamContext context)
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

            if (user.ImageUrl != originalEntity.ImageUrl)
                originalEntity.ImageUrl = user.ImageUrl;

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
            if (string.IsNullOrEmpty(user.Token) && entity.Password != GetMd5Hash(user.Password))
            {
                return false;
            }

            entity.Password = GetMd5Hash(user.NewPassword);
            entity.Token = string.Empty;

            UserRepository.Update(entity);

            return true;
        }

        public async System.Threading.Tasks.Task<bool> ResetPasswordAsync(string email)
        {
            var tokenid = Guid.NewGuid();
            var user = UserRepository.GetByEmail(email);
            if (user == null)
            {
                return false;
            }
            user.Token = tokenid.ToString();

            UserRepository.Update(user);

            string url = "https://icescreamstorage.blob.core.windows.net/templates/SendResetPassword.htm";
            string response = string.Empty;
            using (var client = new HttpClient())
            {
                response = await client.GetStringAsync(url);
            }

            response = response.Replace("{{name}}", user.Name);
            response = response.Replace("{{action_url}}", string.Format("{0}?token={1}", "https://icescreamapp.herokuapp.com/recoverypassword", tokenid));

            SendEmail sendEmail = new SendEmail();
            sendEmail.SendEmailIceScream(user.Name, user.Email, "Recuperação de senha", response);

            return true;
        }

        public User RecoveryPasswordToken(string token)
        {
            return UserRepository.GetByToken(token);
        }

        public void EnableDisable(User user, bool active)
        {
            user.Active = active;
            UserRepository.Update(user);
        }
    }
}