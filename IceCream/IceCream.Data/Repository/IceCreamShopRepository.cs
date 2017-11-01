using System.Collections.Generic;
using System.Linq;
using IceCream.Data.Models;

namespace IceCream.Data.Repository
{
    public class IceCreamShopRepository
    {
        private DBIceScreamContext Context { get; set; }

        public IceCreamShopRepository(DBIceScreamContext context)
        {
            Context = context;
        }

        public void Add(IceCreamShop item)
        {
            Context.IceCreamShop.Add(item);
            Context.SaveChanges();
        }

        public void Delete(int Id)
        {
            var deleteItem = Context.IceCreamShop.SingleOrDefault(r => r.IdIceCreamShop == Id);
            Context.IceCreamShop.Remove(deleteItem);
            Context.SaveChanges();
        }

        public IceCreamShop Get(int id)
        {
            return Context.IceCreamShop.Where(e => e.IdIceCreamShop.Equals(id)).FirstOrDefault();
        }

        public List<IceCreamShop> GetAll()
        {
            List<IceCreamShop> ListIceCreamShop = new List<IceCreamShop>();

            ListIceCreamShop = Context.IceCreamShop.ToList();

            return ListIceCreamShop;
        }

        public void Update(IceCreamShop item)
        {
            var updateIceCreamShop = Context.IceCreamShop.SingleOrDefault(i => i.IdIceCreamShop == item.IdIceCreamShop);
            if (updateIceCreamShop != null)
            {
                updateIceCreamShop.Name = item.Name;
                updateIceCreamShop.Address = item.Address;
                updateIceCreamShop.Phone = item.Phone;
                updateIceCreamShop.AveragePrice = item.AveragePrice;
                updateIceCreamShop.PaymentMethods = item.PaymentMethods;
                Context.SaveChanges();
            }
        }
    }
}
