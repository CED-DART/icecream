using System.Collections.Generic;
using System.Linq;
using IceCream.Data.Context;
using IceCream.Data.Models;

namespace IceCream.Data.Repository
{
    public class IceCreamShopRepository
    {
        public void Add(IceCreamShop item)
        {
            using (IceCreamManagementContext repository = new IceCreamManagementContext())
            {
                repository.IceCreamShop.Add(item);
            }
        }

        public void Delete(int Id)
        {
            using (IceCreamManagementContext repository = new IceCreamManagementContext())
            {
                var deleteItem = repository.IceCreamShop.SingleOrDefault(r => r.IdIceCreamShop == Id);
                repository.IceCreamShop.Remove(deleteItem);
            }
        }

        public IceCreamShop Get(int id)
        {
            using (IceCreamManagementContext repository = new IceCreamManagementContext())
            {
                return repository.IceCreamShop.Where(e => e.IdIceCreamShop.Equals(id)).FirstOrDefault();
            }
        }

        public List<IceCreamShop> GetAll()
        {
            List<IceCreamShop> ListIceCreamShop = new List<IceCreamShop>();
            using (IceCreamManagementContext repository = new IceCreamManagementContext())
            {
                ListIceCreamShop = repository.IceCreamShop.ToList();
            }
            return ListIceCreamShop;
        }

        public void Update(IceCreamShop item)
        {
            using (IceCreamManagementContext repository = new IceCreamManagementContext())
            {
                var updateIceCreamShop = repository.IceCreamShop.SingleOrDefault(i => i.IdIceCreamShop == item.IdIceCreamShop);
                if (updateIceCreamShop != null)
                {
                    updateIceCreamShop.Name = item.Name;
                    updateIceCreamShop.Address = item.Address;
                    updateIceCreamShop.Phone = item.Phone;
                    updateIceCreamShop.AveragePrice = item.AveragePrice;
                    updateIceCreamShop.PaymentMethods = item.PaymentMethods;
                }
            }
        }
    }
}
