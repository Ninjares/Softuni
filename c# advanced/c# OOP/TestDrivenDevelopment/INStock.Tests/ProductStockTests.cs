namespace INStock.Tests
{
    using NUnit.Framework;
    using Contracts;
    using System;
    using System.Linq;
    public class ProductStockTests
    {
        private IProductStock products;
        [Test]
        public void DiplicateLabelAfterProductAdd()
        {
            int CountBeforeAdd = products.Count;
            products.Add(new Product() { Label = "MyProduct", Quantity = 2, Price = 90m });
            Assert.AreEqual(CountBeforeAdd, products.Count);
            //Assert.Throws<Exception>(() => new Product() { Label = "MyProduct" });
        }
        [Test]
        public void ProductQuantityIncreasedByQuantity()
        {
            int QuantitiyBeforeAdd = products.Find(0).Quantity;
            products.Add(new Product() { Label = "MyProduct" , Quantity = 2});
            Assert.AreEqual(QuantitiyBeforeAdd+2, products.Find(0).Quantity);
        }
        [Test]
        public void PriceReservedAfterAddedProduct()
        {
            decimal pricebeforeAdd = products.Find(0).Price;
            products.Add(new Product() { Label = "MyProduct", Quantity = 1, Price = 50m });
            Assert.AreEqual(pricebeforeAdd, products.Find(0).Price);
        }
        [SetUp]
        public void CreateTestObjects()
        {
            products = new ProductStock();
            products.Add(new Product() { Label = "MyProduct", Quantity = 1, Price = 100m}); //different price
        }
        [TearDown]
        public void DestroyObjects()
        {

        }
        
    }
}
