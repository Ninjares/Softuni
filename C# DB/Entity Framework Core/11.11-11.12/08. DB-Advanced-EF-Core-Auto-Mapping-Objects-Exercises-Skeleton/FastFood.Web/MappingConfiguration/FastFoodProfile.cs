namespace FastFood.Web.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Web.ViewModels.Categories;
    using FastFood.Web.ViewModels.Employees;
    using FastFood.Web.ViewModels.Items;
    using Models;

    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));
            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));
            //Categories
            CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.CategoryName));
            CreateMap<Category, CategoryAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            //Items
            CreateMap<CreateItemInputModel, Item>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name))
                .ForMember(x => x.Price, y => y.MapFrom(s => s.Price))
                .ForMember(x => x.CategoryId, y => y.MapFrom(s => s.CategoryId));
            CreateMap<Item, ItemsAllViewModels>()
                .ForMember(x => x.Category, y => y.MapFrom(s => s.Category.Name))
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name))
                .ForMember(x => x.Price, y => y.MapFrom(s => s.Price));


        }
    }
}
