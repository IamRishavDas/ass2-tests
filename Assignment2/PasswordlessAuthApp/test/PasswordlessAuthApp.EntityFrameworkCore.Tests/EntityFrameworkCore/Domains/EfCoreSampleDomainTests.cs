using PasswordlessAuthApp.Samples;
using Xunit;

namespace PasswordlessAuthApp.EntityFrameworkCore.Domains;

[Collection(PasswordlessAuthAppTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<PasswordlessAuthAppEntityFrameworkCoreTestModule>
{

}
