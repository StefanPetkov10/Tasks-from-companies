using AutoMapper;
using NotesVaultApp.Data.Models;

namespace NotesVaultApp.DTOs.Note_DTOs.Mappings
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<Note, NoteDto>()
                .ForMember(x => x.Category, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(x => x.User, opt => opt.MapFrom(src => src.User.Username));

            CreateMap<CreateNoteDto, Note>()
                //.ForMember(dest => dest.Category, opt => opt.MapFrom(src => Enum.Parse<Categories>(src.Category.ToString())))
                .ForMember(dest => dest.Category, opt => opt.Ignore())
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
            // From CreateNoteDto to Note
            CreateMap<UpdateNoteDto, Note>(); // From UpdateNoteDto to Note
        }
    }
}
