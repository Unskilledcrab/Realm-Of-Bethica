using AutoMapper;
using ROBaspCore.Models;
using ROBaspCore.ViewModels;

namespace ROBaspCore.Data.MapperProfiles
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
