using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary.Models
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<Status, StatusModel>().ReverseMap();
            CreateMap<Gender, GenderModel>().ReverseMap();
            CreateMap<ProductSize, ProductSizeModel>().ReverseMap();
            CreateMap<Colors, ColorsModel>().ReverseMap();
        }
    }
}
