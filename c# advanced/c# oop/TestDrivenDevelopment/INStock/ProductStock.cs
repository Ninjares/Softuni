using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using INStock.Contracts;

namespace INStock
{
    public class ProductStock : IProductStock
    {
        private const int MaxCap = 100000;
        private List<IProduct> products;

        public ProductStock()
        {
            products = new List<IProduct>();
        }
        public IProduct this[int index] { get => products[index]; set => products[index]=value; }

        public int Count { get => products.Count; }

        public void Add(IProduct product)
        {
            try
            {
                var existingProduct = (Product)this.FindByLabel(product.Label); //In case of an existing product we only raise the quantity
                existingProduct.Quantity += product.Quantity;
            }
            catch(Exception)
            {
                
            }
            if (!products.Any(x=> x.Label==product.Label)) products.Add(product);
        }

        public bool Contains(IProduct product)
        {
            return products.Contains(product);
        }

        public IProduct Find(int index)
        {
            return products[index];
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProduct> FindAllInRange(double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IProduct FindByLabel(string label)
        {
            var product = products.FirstOrDefault(x => x.Label == label);
            if (product == null) throw new ArgumentNullException();
            return product;
        }

        public IProduct FindMostExpensiveProduct()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(IProduct product)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
