using AutoMapper;
using AutoMapperTest.Models;
using AutoMapperTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperTest.Helper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            //CreateMap<User, EditUserViewModel>()
            //    .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Email));

            //CreateMap<EditUserViewModel, User>()
            //    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Login));

            CreateMap<User, EditUserViewModel>().ReverseMap();
            CreateMap<User, IndexUserViewModel>();
            CreateMap<User, DeleteUserViewModel>().ReverseMap();
            CreateMap<CreateUserViewModel, User>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(c => c.FirstName + " " + c.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Login));


        }
    }
}
