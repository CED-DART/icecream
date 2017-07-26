using System.Collections.Generic;
using System.Text;
using IceCream.Data.Context;
using IceCream.Data.Models;
using System.Linq;

namespace IceCream.Data.Repository
{
    public class IceCreamRepository
    {
        //static List<IceCreamShop> ListIceCreamShop = new List<IceCreamShop>();
        //public void Add(IceCreamShop item)
        //{
        //    ListIceCreamShop.Add(item);
        //}

        //public void Delete(int Id)
        //{
        //    var deleteItem = ListIceCreamShop.SingleOrDefault(r => r.IdIceCreamShop == Id);
        //    if (ListIceCreamShop != null)
        //    {
        //        ListIceCreamShop.Remove(deleteItem);
        //    }
        //}

        //public IceCreamShop Get(int id)
        //{
        //    return ListIceCreamShop.Where(e => e.IdIceCreamShop.Equals(id)).FirstOrDefault();
        //}

        //public IEnumerable<IceCreamShop> GetAll()
        //{
        //    return ListIceCreamShop;
        //}

        //public void Update(IceCreamShop item)
        //{
        //    var updateIceCreamShop = ListIceCreamShop.SingleOrDefault(i => i.IdIceCreamShop == item.IdIceCreamShop);
        //    if (updateIceCreamShop != null)
        //    {
        //        updateIceCreamShop.Name = item.Name;
        //        updateIceCreamShop.Address = item.Address;
        //        updateIceCreamShop.Phone = item.Phone;
        //        updateIceCreamShop.AveragePrice = item.AveragePrice;
        //        updateIceCreamShop.PaymentMethods = item.PaymentMethods;
        //    }
        //}
    }
}
