using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<Dtos.Import.User, Models.User>()
                .ForMember(x => x.FirstName, y => y.MapFrom(s => s.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(s => s.LastName))
                .ForMember(x => x.Age, y => y.MapFrom(s => s.Age));

            this.CreateMap<Dtos.Import.Product, Models.Product>()
                .ForMember(x => x.Name, o => o.MapFrom(s => s.Name))
                .ForMember(x => x.Price, o => o.MapFrom(s => s.Price))
                .ForMember(x => x.SellerId, o => o.MapFrom(s => s.SellerId))
                .ForMember(x => x.BuyerId, o => o.MapFrom(s => s.BuyerId));

            this.CreateMap<Dtos.Import.Category, Models.Category>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name));

            this.CreateMap<Dtos.Import.CategoryProduct, Models.CategoryProduct>()
                .ForMember(d => d.CategoryId, o => o.MapFrom(s => s.CategoryId))
                .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ProductId));

            this.CreateMap<Models.Product, Dtos.Export.Product>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.Price, o => o.MapFrom(s => s.Price))
                .ForMember(d => d.BuyerFullName, o => o.MapFrom(s => s.Buyer.FirstName + " " + s.Buyer.LastName));

            this.CreateMap<Models.Category, Dtos.Export.CategoryDto>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.Count, o => o.MapFrom(s => s.CategoryProducts.Count))
                .ForMember(d => d.AvgPrice, o => o.MapFrom(s => s.CategoryProducts.Average(cp => cp.Product.Price)))
                .ForMember(d => d.TotalRevenue, o => o.MapFrom(s => s.CategoryProducts.Sum(cp => cp.Product.Price)));

            this.CreateMap<Models.User, Dtos.Export.UserDto>()
                .ForMember(d => d.firstName, o => o.MapFrom(s => s.FirstName))
                .ForMember(d => d.lastName, o => o.MapFrom(s => s.LastName))
                .ForMember(d => d.age, o => o.MapFrom(s => s.Age))
                .ForMember(d => d.SoldProducts, o => o.MapFrom(s => new Dtos.Export.SoldProductsDto()
                {
                    count = s.ProductsSold.Count,
                    products = s.ProductsSold.Select(x => new Dtos.Export.ProductDto()
                    {
                        name = x.Name,
                        price = x.Price
                    }).OrderByDescending(x => x.price).ToArray()
                })) ;
        }
    }
}
