using WarehouseDataLayer.APIs;
using WarehouseLogicLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLogicLayer
{
    internal class ProductCRUD : IProductCRUD
    {
        private IDataRepository _dataRepository;

        public ProductCRUD(IDataRepository dataRepository)
        {
            this._dataRepository = dataRepository;
        }

        private IProductDTO Map(IProduct Product)
        {
            return new ProductDTO(Product.ID, Product.Name, Product.Producer, Product.Description);
        }

        public void AddProduct(int ProductID, string Name, string Producer, string Description)
        {
            this._dataRepository.AddProduct(ProductID, Name, Producer, Description);
        }

        public IProductDTO GetProduct(int ProductID)
        {
            return this.Map(this._dataRepository.GetProduct(ProductID));
        }

        public Dictionary<int, IProductDTO> GetProducts()
        {
            Dictionary<int, IProductDTO> Products = new Dictionary<int, IProductDTO>();

            foreach (IProduct Product in (this._dataRepository.GetProducts()).Values)
            {
                Products.Add(Product.ID, this.Map(Product));
            }

            return Products;
        }

        public void UpdateProduct(int ProductID, string Name, string Producer, string Description)
        {
            this._dataRepository.UpdateProduct(ProductID, Name, Producer, Description);
        }

        public void DeleteProduct(int ProductID)
        {
            this._dataRepository.DeleteProduct(ProductID);
        }
    }
}
