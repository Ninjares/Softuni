namespace ProductShop.Dtos.Export
{
    using System.Xml.Serialization;
    
    public class Users
    {
        public int count { get; set; }
        public UserDto[] users { get; set; }

    }
    [XmlType("User")]
    public class UserDto
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }

        public SoldProductsDto SoldProducts { get; set; }
    }
    public class SoldProductsDto
    {
        public int count { get; set; }
        public ProductDto[] products {get;set;}
    }
    [XmlType("Product")]
    public class ProductDto
    {
        public string name { get; set; }
        public decimal price { get; set; }
    }
}
