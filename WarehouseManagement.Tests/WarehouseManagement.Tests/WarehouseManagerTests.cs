using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WarehouseManagement.Tests
{
    [TestClass]
    public class WarehouseManagerTests
    {
        private WarehouseManager _warehouseManager;

        [SetUp]
        public void Setup()
        {
            // Initialize WarehouseManager instance
            _warehouseManager = new WarehouseManager();
        }

        [Test]
        public void AddProduct_ProductAddedSuccessfully()
        {
            // Arrange
            var product = new Product { ID = 1, Name = "Test Product", Quantity = 10, Price = 50 };

            // Act
            _warehouseManager.AddProduct(product);

            // Assert
            Assert.IsTrue(_warehouseManager.Products.Contains(product));
        }

        [Test]
        public void RemoveProduct_ProductRemovedSuccessfully()
        {
            // Arrange
            var product = new Product { ID = 1, Name = "Test Product", Quantity = 10, Price = 50 };
            _warehouseManager.AddProduct(product);

            // Act
            _warehouseManager.RemoveProduct(product);

            // Assert
            Assert.IsFalse(_warehouseManager.Products.Contains(product));
        }

        // Add more test methods for other functionalities        public void TestMethod1()
        {
        }
    }
}
