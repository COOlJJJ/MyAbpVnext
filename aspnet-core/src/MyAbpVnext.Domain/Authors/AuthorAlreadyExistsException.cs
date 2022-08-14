using Volo.Abp;

namespace MyAbpVnext.Authors
{
    public class AuthorAlreadyExistsException : BusinessException
    {
        public AuthorAlreadyExistsException(string name)
            : base(MyAbpVnextDomainErrorCodes.AuthorAlreadyExists)
        {
            WithData("name", name);
        }
    }
}
