using System;
using System.Collections.Generic;
using System.Linq;
using IceCream.Data.Models;

namespace IceCream.Data.Repository
{
    public class UserDebtorRepository
    {
        private IceCreamManagementContext Context { get; set; }

        public UserDebtorRepository(IceCreamManagementContext context)
        {
            Context = context;
        }

        public List<UserDebtor> GetAllUserDebtor()
        {
            var response = Context.UserDebtor.ToList();

            return response;
        }

        public List<PendingUserDebtor> GetPendingUserDebtor(int? maximumItems)
        {
            var query = Context.UserDebtor.Where(ud => ud.PaymentDate == null).Select(u => new PendingUserDebtor()
            {
                IdUserDebtor = u.IdUserDebtor,
                UserName = u.IdUserNavigation.Name,
                UserContact = u.IdUserNavigation.Contact,
                DebitDate = u.DebitDate,
                Reason = u.Reason
            });

            if(maximumItems.HasValue)
            {
               query = query.Take(maximumItems.Value);
            }

            var response = query.ToList();

            return response;
        }
        
        public List<UserDebtor> GetUserDebtorByUser(int idUser)
        {
            var response = Context.UserDebtor.Where(ud => ud.IdUser == idUser).ToList();

            return response;
        }

        public UserDebtor Get(int id)
        {
            var user = Context.UserDebtor.FirstOrDefault(u => u.IdUserDebtor == id);

            return user;
        }

        public void Add(UserDebtor userDebtor)
        {
            userDebtor.Created = DateTime.Now;
            Context.UserDebtor.Add(userDebtor);

            Context.SaveChanges();
        }

    }
}