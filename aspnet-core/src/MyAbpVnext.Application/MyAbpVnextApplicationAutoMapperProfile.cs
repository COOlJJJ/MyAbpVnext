using AutoMapper;
using MyAbpVnext.Authors;
using MyAbpVnext.Books;
using Volo.Abp.AuditLogging;

namespace MyAbpVnext;

public class MyAbpVnextApplicationAutoMapperProfile : Profile
{
    public MyAbpVnextApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();

        CreateMap<Author, AuthorDto>();
        CreateMap<Author, AuthorLookupDto>();

        //AuditLog
        CreateMap<AuditLog, AuditLogDto>()
            .MapExtraProperties();

        CreateMap<EntityChange, EntityChangeDto>()
            .MapExtraProperties();

        CreateMap<EntityPropertyChange, EntityPropertyChangeDto>();

        CreateMap<AuditLogAction, AuditLogActionDto>();
    }
}
