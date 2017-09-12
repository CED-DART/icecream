using IceCream.Data.Models;
using IceCream.Data.Repository;
using System.Collections.Generic;

namespace IceCream.Business.Component
{
    public class IceCreamShopComponent
    {
        private IceCreamShopRepository IceCreamShopRepository { get; set; }
        
        public IceCreamShopComponent(IceCreamManagementContext context)
        {
            IceCreamShopRepository = new IceCreamShopRepository(context);
        }

        public void Add(IceCreamShop item)
        {
            IceCreamShopRepository.Add(item);
        }

        public void Delete(int Id)
        {
            IceCreamShopRepository.Delete(Id);
        }

        public IceCreamShop Get(int id)
        {
            return IceCreamShopRepository.Get(id);
        }

        public List<IceCreamShop> GetAll()
        {
            return IceCreamShopRepository.GetAll();
        }

        public void Update(IceCreamShop originalEntity, IceCreamShop item)
        {
            if (!string.IsNullOrEmpty(item.Name) && item.Name != originalEntity.Name)
                originalEntity.Name = item.Name;
            
            if (!string.IsNullOrEmpty(item.Address) && item.Address != originalEntity.Address)
                originalEntity.Address = item.Address;

            if (!string.IsNullOrEmpty(item.Phone) && item.Phone != originalEntity.Phone)
                originalEntity.Phone = item.Phone;

            if (!string.IsNullOrEmpty(item.PaymentMethods) && item.PaymentMethods != originalEntity.PaymentMethods)
                originalEntity.PaymentMethods = item.PaymentMethods;

            if (item.AveragePrice != null && item.AveragePrice != originalEntity.AveragePrice)
                originalEntity.AveragePrice = item.AveragePrice;

            IceCreamShopRepository.Update(item);
        }
    }
}
