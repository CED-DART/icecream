
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
        private UserComponent UserComponent { get; set; }
        public UserDebtorComponent(IceCreamManagementContext context)
        {
            UserDebtorRepository = new UserDebtorRepository(context);
            UserComponent = new UserComponent(context);
        }

        public List<UserDebtor> GetAllUserDebtor()
        {
            return UserDebtorRepository.GetAllUserDebtor();
        }

        public List<PendingUserDebtor> GetPendingUserDebtor(int? maximumItems)
        {
            return UserDebtorRepository.GetPendingUserDebtor(maximumItems);
        }

        public List<UserDebtor> GetUserDebtorByUser(int idUser)
        {
            return UserDebtorRepository.GetUserDebtorByUser(idUser);
        }

        public void CreatePendingDebtors()
        {
            var users = UserComponent.GetUserWithAcceptance();
            
            //TODO: Método de criação de débitos

            throw new NotImplementedException();
        }        
    }
}