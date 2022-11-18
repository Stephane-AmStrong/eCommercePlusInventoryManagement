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
            CreateMap<AppUser, AppUserDto>().ReverseMap();
            CreateMap<AppUser, AppUsersDto>().ReverseMap();

            CreateMap<InventoryLevel, InventoryLevelDto>().ReverseMap();
            CreateMap<InventoryLevel, InventoryLevelsDto>().ReverseMap();
            
            CreateMap<Item, ItemDto>().ReverseMap();
            CreateMap<Item, ItemsDto>().ReverseMap();
            
            CreateMap<ItemCategory, ItemCategoryDto>().ReverseMap();
            CreateMap<ItemCategory, ItemCategoriesDto>().ReverseMap();
            
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, OrdersDto>().ReverseMap();
            
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemsDto>().ReverseMap();
            

        }
    }
}
