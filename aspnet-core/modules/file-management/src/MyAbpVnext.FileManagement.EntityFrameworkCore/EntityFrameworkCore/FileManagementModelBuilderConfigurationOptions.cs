using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace MyAbpVnext.FileManagement.EntityFrameworkCore
{
    public class FileManagementModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public FileManagementModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}