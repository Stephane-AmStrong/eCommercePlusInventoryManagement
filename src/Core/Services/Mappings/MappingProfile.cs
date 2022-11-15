using AutoMapper;
using DataTransfertObjects;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, AppUserReadDto>().ReverseMap();
            CreateMap<AppUser, AppUsersReadDto>().ReverseMap();
            CreateMap<AppUser, AppUserWriteDto>().ReverseMap();

            CreateMap<InventoryLevel, InventoryLevelReadDto>().ReverseMap();
            CreateMap<InventoryLevel, InventoryLevelsReadDto>().ReverseMap();
            CreateMap<InventoryLevel, InventoryLevelWriteDto>().ReverseMap();
            
            CreateMap<Item, ItemReadDto>().ReverseMap();
            CreateMap<Item, ItemsReadDto>().ReverseMap();
            CreateMap<Item, ItemWriteDto>().ReverseMap();
            
            CreateMap<ItemCategory, ItemCategoryReadDto>().ReverseMap();
            CreateMap<ItemCategory, ItemCategoriesReadDto>().ReverseMap();
            CreateMap<ItemCategory, ItemCategoryWriteDto>().ReverseMap();
            
            CreateMap<Order, OrderReadDto>().ReverseMap();
            CreateMap<Order, OrdersReadDto>().ReverseMap();
            CreateMap<Order, OrderWriteDto>().ReverseMap();
            
            CreateMap<OrderItem, OrderItemReadDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemsReadDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemWriteDto>().ReverseMap();
            

        }
    }
}
