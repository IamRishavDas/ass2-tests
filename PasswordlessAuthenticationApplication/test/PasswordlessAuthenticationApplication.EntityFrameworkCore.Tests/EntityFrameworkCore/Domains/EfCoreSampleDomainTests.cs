using PasswordlessAuthenticationApplication.Samples;
using Xunit;

namespace PasswordlessAuthenticationApplication.EntityFrameworkCore.Domains;

[Collection(PasswordlessAuthenticationApplicationTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<PasswordlessAuthenticationApplicationEntityFrameworkCoreTestModule>
{

}
