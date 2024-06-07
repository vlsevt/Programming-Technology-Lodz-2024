using WarehouseDataLayer.APIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLogicLayer.API
{
    public interface IProductCRUD
    {
        static IProductCRUD CreateProductCRUD(IDataRepository? dataRepository = null)
        {
            return new ProductCRUD(dataRepository ?? IDataRepository.CreateDatabase());
        }

        void AddProduct(int ProductID, string Name, string Producer, string Description);
        IProductDTO GetProduct(int ProductID);
        Dictionary<int, IProductDTO> GetProducts();
        void UpdateProduct(int ProductID, string Name, string Producer, string Description);
        void DeleteProduct(int ProductID);
    }
}
