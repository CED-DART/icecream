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

        public void Update(IceCreamShop item)
        {
            IceCreamShopRepository.Update(item);
        }
    }
}
