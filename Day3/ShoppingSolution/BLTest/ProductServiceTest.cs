using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
namespace BLTest
{
    public class ProductServiceTest
    {
        IProductService _productService;
        [SetUp]
        public void Setup()
        {
            _productService = new ProductService();
        }

        [Test]
        public void AddProductTest()
        {
            var result = _productService.AddProduct(new Product { Id = 100, Name = "Pencil" });
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetAllProductsTest()
        {
            //Arrange
            var prod = _productService.AddProduct(new Product { Id = 100, Name = "Pencil" });
            //Action
            var result = _productService.GetProducts();
            //Assert
            Assert.AreEqual(1, result.Count);
        }
        [TestCase(1, "Pencil")]
        public void GetProductTest(int id,string Name)
        {
            var prod = _productService.AddProduct(new Product { Name = "Pencil" });
            var result = _productService.GetProduct(1);
            Assert.That(result.Id, Is.EqualTo(id));
        }
    }
}