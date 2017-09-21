
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

            foreach (var user in users)
            {
                
            }
        }

        public DateTime? GetLastPaymentDate()
        {
            return UserDebtorRepository.GetLastPaymentDate();
        }
        public void RequestPayment(RequestUserDebtorPayment requestPayment)  
        {
            if (requestPayment.PaymentDate == null)
            {
                throw new Exception("Data de pagamento é obrigatória");
            }

            if (requestPayment.Evaluation == null)
            {
                throw new Exception("Avaliação é obrigatória");
            }

           var userDebtor = UserDebtorRepository.Get(requestPayment.IdUserDebtor);

            if (userDebtor == null)
            {
                throw new Exception("Débito não encontrado");
            }

            if (userDebtor.PaymentDate != null)
            {
                throw new Exception("Pagamento já baixado");
            }

            UserDebtorRepository.UpdateRequestPayment(requestPayment);
        }
        
        public List<EvaluationData> GetAllEvaluationData()
        {
            return UserDebtorRepository.GetAllEvaluationData();
        }
    }
}