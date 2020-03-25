using AutoMapper;
using ROBaspCore.Models;
using ROBaspCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROBaspCore.Data.MapperProfiles
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
