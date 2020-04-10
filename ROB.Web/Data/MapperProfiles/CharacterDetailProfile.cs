using AutoMapper;
using ROB.Web.Models;
using ROB.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROB.Web.Data.MapperProfiles
{
    public class CharacterDetailProfile : Profile
    {
        public CharacterDetailProfile()
        {
            this.CreateMap<CharacterSheetModel, CharacterDetailsViewModel>();
            this.CreateMap<CharacterDetailsViewModel, CharacterSheetModel>();
        }
    }
}
