using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CarDealer.DTO;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<SuppliersInputModel, Supplier>();
            CreateMap<PartsInputModel, Part>();
            CreateMap<CarsInputModel, Car>();
            CreateMap<CustomersInputModel, Customer>();
            CreateMap<SalesInputModel, Sale>();
        }
    }
}
