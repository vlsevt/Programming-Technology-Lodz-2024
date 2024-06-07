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

        void AddProduct(int ProductId, string author, string name);
        IProductDTO GetProduct(int ProductId);
        Dictionary<int, IProductDTO> GetProducts();
        void UpdateProduct(int ProductId, string author, string name);
        void DeleteProduct(int ProductId);
    }
}
