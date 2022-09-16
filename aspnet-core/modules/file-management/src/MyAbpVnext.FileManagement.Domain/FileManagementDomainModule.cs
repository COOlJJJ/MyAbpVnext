using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using Volo.Abp.BlobStoring;

namespace MyAbpVnext.FileManagement;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(FileManagementDomainSharedModule),
    typeof(AbpBlobStoringModule)
)]
public class FileManagementDomainModule : AbpModule
{

}
