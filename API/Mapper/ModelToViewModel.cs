using API.ViewModels;
using AutoMapper;
using Library.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Mapper
{
    public class ModelToViewModel : Profile
    {
        public ModelToViewModel()
        {
            CreateMap<Room, RoomViewModel>()
                .ForMember(vm => vm.ID, map => map.MapFrom(m => m.ID))
                .ForMember(vm => vm.ApartmentID, map => map.MapFrom(m => m.ApartmentID))
                .ForMember(vm => vm.RoomTypeID, map => map.MapFrom(m => m.RoomTypeID))
                .ForMember(vm => vm.RoomName, map => map.MapFrom(m => m.RoomName))
                .ForMember(vm => vm.Capacity, map => map.MapFrom(m => m.Capacity))
                .ForMember(vm => vm.Floor, map => map.MapFrom(m => m.Floor))
                .ForMember(vm => vm.Available, map => map.MapFrom(m => m.Available))
                .ForMember(vm => vm.Periods, map => map.MapFrom(m => m.Periods.Where(x => x.isActive == true)))
                ;
        }
    }
}