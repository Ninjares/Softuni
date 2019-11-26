﻿namespace ProductShop.Models
{
    using System.Xml.Serialization;
    public class CategoryProduct
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
