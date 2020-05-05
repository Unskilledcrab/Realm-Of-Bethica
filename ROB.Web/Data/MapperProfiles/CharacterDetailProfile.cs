using AutoMapper;
using ROB.Web.Models;
using ROB.Web.ViewModels;

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
