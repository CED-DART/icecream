
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using IceCream.Data.Models;
using IceCream.Data.Repository;

namespace IceCream.Business.Component
{
    public class UserDebtorComponent
    {
        private UserDebtorRepository UserDebtorRepository { get; set; }

        public UserDebtorComponent(IceCreamManagementContext context)
        {
            UserDebtorRepository = new UserDebtorRepository(context);
        }

        public List<UserDebtor> GetAllUserDebtor()
        {
            return UserDebtorRepository.GetAllUserDebtor();
        }

        public List<UserDebtor> GetUserDebtorByUser(int idUser)
        {
            return UserDebtorRepository.GetUserDebtorByUser(idUser);
        }

        public void CreatePendingDebtors()
        {
            //TODO: Método de criação de débitos

            throw new NotImplementedException();
        }        
    }
}