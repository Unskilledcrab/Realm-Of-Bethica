using AutoMapper;
using ROB.Web.Models;
using ROB.Web.ViewModels;

namespace ROB.Web.Data.MapperProfiles
{
    public class CharacterNoteProfile : Profile
    {
        public CharacterNoteProfile()
        {
            this.CreateMap<CharacterSheetModel, CharacterNotesViewModel>();
            this.CreateMap<CharacterNotesViewModel, CharacterSheetModel>();
        }
    }
}
