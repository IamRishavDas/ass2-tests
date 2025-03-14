using PasswordlessAuthApp.Samples;
using Xunit;

namespace PasswordlessAuthApp.EntityFrameworkCore.Applications;

[Collection(PasswordlessAuthAppTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<PasswordlessAuthAppEntityFrameworkCoreTestModule>
{

}
