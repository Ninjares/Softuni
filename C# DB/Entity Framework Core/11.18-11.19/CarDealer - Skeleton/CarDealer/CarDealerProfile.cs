using AutoMapper;

namespace CarDealer
{
    using Models;
    using Dtos.Import;
    using CarDealer.Dtos.Export;
    using System.Linq;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<SupplierDtoI, Supplier>()
                .ForMember(x => x.Name, o => o.MapFrom(s => s.name))
                .ForMember(x => x.IsImporter, o => o.MapFrom(s => s.isImporter));

            this.CreateMap<PartDtoI, Part>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.name))
                .ForMember(d => d.Price, o => o.MapFrom(s => s.price))
                .ForMember(d => d.Quantity, o => o.MapFrom(s => s.quantity))
                .ForMember(d => d.SupplierId, o => o.MapFrom(s => s.supplierId));

            this.CreateMap<CarDtoI, Car>()
                .ForMember(d => d.Make, o => o.MapFrom(s => s.make))
                .ForMember(d => d.Model, o => o.MapFrom(s => s.model))
                .ForMember(d => d.TravelledDistance, o => o.MapFrom(s => s.TraveledDistance));

            this.CreateMap<CustomerDtoI, Customer>()
                .ForMember(d => d.BirthDate, o => o.MapFrom(s => s.birthDate))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.name))
                .ForMember(d => d.IsYoungDriver, o => o.MapFrom(s => s.isYoungDriver));

            this.CreateMap<Customer, CustomerDtoO>()
                .ForMember(x => x.FullName, o => o.MapFrom(s => s.Name))
                .ForMember(x => x.BoughtCars, o => o.MapFrom(s => s.Sales.Count))
                .ForMember(x => x.SpentMoney, o => o.MapFrom(s => s.Sales.Sum(sl => sl.Car.PartCars.Sum(p => p.Part.Price))));

        }
    }
}
