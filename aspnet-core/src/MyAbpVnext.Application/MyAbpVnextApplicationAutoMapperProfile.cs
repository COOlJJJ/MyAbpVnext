using AutoMapper;
using MyAbpVnext.Authors;
using MyAbpVnext.Books;

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
    }
}
