using WarehouseDataLayer.APIs;
using WarehouseDataLayer.Database;
using WarehouseLogicLayer.API;
using WarehouseLogicLayer.Fake;

namespace WarehouseLogicTest
{
    [TestClass]
    public class LogicTests
    {
        //private readonly IDataRepository _dataRepository = new DataRepositoryFake();

        DataRepositoryFake _dataRepository = new DataRepositoryFake();


        [TestMethod]
        public void UserLogicTests()
        {
            IUserCRUD UserCrud = IUserCRUD.CreateUserCRUD(this._dataRepository);

            UserCrud.AddUser(1, "John", "Wrublevski");

            IUserDTO User = UserCrud.GetUser(1);

            Assert.IsNotNull(User);
            Assert.AreEqual(1, User.ID);
            Assert.AreEqual("John", User.Name);
            Assert.AreEqual("Wrublevski", User.Surname);

            Assert.IsNotNull(UserCrud.GetUsers());

            UserCrud.UpdateUser(1, "Marisa", "Bunner");

            IUserDTO updatedUser = UserCrud.GetUser(1);

            Assert.IsNotNull(updatedUser);
            Assert.AreEqual(1, updatedUser.ID);
            Assert.AreEqual("Marisa", updatedUser.Name);
            Assert.AreEqual("Bunner", updatedUser.Surname);

            UserCrud.DeleteUser(1);
        }

        [TestMethod]
        public void ProductLogicTests()
        {
            IProductCRUD ProductCrud = IProductCRUD.CreateProductCRUD(this._dataRepository);

            ProductCrud.AddProduct(1, "Cleaning kit", "Cecil Martin", "Nice thing");

            IProductDTO Product = ProductCrud.GetProduct(1);

            Assert.IsNotNull(Product);
            Assert.AreEqual(1, Product.ID);
            Assert.AreEqual("Clean Code", Product.Name);
            Assert.AreEqual("Cecil Martin", Product.Producer);
            Assert.AreEqual("Nice thing", Product.Description);

            Assert.IsNotNull(ProductCrud.GetProducts());

            ProductCrud.UpdateProduct(1, "Wild rug", "Aditya", "Nice thing");

            IProductDTO updatedProduct = ProductCrud.GetProduct(1);

            Assert.IsNotNull(updatedProduct);
            Assert.AreEqual(1, updatedProduct.ID);
            Assert.AreEqual("Grokking Algorithms", updatedProduct.Name);
            Assert.AreEqual("Aditya Y. Bhargava", updatedProduct.Producer);
            Assert.AreEqual("Nice thing", Product.Description);


            ProductCrud.DeleteProduct(1);
        }

        [TestMethod]
        public void StateLogicTests()
        {
            IProductCRUD ProductCrud = IProductCRUD.CreateProductCRUD(this._dataRepository);
            ProductCrud.AddProduct(1, "Cleaning kit", "Cecil Martin", "Nice thing");
            IProductDTO Product = ProductCrud.GetProduct(1);

            IStateCRUD stateCrud = IStateCRUD.CreateStateCRUD(this._dataRepository);

            stateCrud.AddState(1, Product.ID, 12);

            IStateDTO state = stateCrud.GetState(1);

            Assert.IsNotNull(state);
            Assert.AreEqual(1, state.ID);
            Assert.AreEqual(Product.ID, state.ProductID);
            Assert.AreEqual(12, state.Quantity);

            stateCrud.UpdateState(1, Product.ID, 20);

            IStateDTO updatedState = stateCrud.GetState(1);

            Assert.IsNotNull(updatedState);
            Assert.AreEqual(1, updatedState.ID);
            Assert.AreEqual(Product.ID, updatedState.ProductID);
            Assert.AreEqual(20, updatedState.Quantity);

            stateCrud.DeleteState(1);
            ProductCrud.DeleteProduct(1);
        }

        [TestMethod]
        public void OrderLogicTest()
        {
            IUserCRUD UserCrud = IUserCRUD.CreateUserCRUD(this._dataRepository);
            UserCrud.AddUser(1, "John", "Wick");
            IUserDTO User = UserCrud.GetUser(1);

            IProductCRUD ProductCrud = IProductCRUD.CreateProductCRUD(this._dataRepository);
            ProductCrud.AddProduct(1, "Cleaning kit", "Cecil Martin", "Nice thing");
            IProductDTO Product = ProductCrud.GetProduct(1);

            IStateCRUD stateCrud = IStateCRUD.CreateStateCRUD(this._dataRepository);
            stateCrud.AddState(1, Product.ID, 12);
            IStateDTO state = stateCrud.GetState(1);

            IOrderCRUD OrderCrud = IOrderCRUD.CreateOrderCRUD(this._dataRepository);
            OrderCrud.AddOrder(1, User.ID, state.ID, 15);
            IOrderDTO Order = OrderCrud.GetOrder(1);

            Assert.IsNotNull(Order);
            Assert.AreEqual(1, Order.ID);
            Assert.AreEqual(User.ID, Order.UserID);
            Assert.AreEqual(state.ID, Order.StateID);
            Assert.AreEqual(15, Order.Quantity);

            OrderCrud.UpdateOrder(Order.ID, User.ID, state.ID, DateTime.Now, 5);

            IOrderDTO updatedOrder = OrderCrud.GetOrder(Order.ID);

            Assert.IsNotNull(updatedOrder);
            Assert.AreEqual(User.ID, updatedOrder.UserID);
            Assert.AreEqual(state.ID, updatedOrder.StateID);
            Assert.AreEqual(5, updatedOrder.Quantity);

            OrderCrud.DeleteOrder(Order.ID);
            stateCrud.DeleteState(state.ID);
            ProductCrud.DeleteProduct(Product.ID);
            UserCrud.DeleteUser(User.ID);
        }
    }
}