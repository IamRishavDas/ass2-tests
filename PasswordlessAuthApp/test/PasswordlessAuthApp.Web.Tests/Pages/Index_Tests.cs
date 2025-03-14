using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace PasswordlessAuthApp.Pages;

[Collection(PasswordlessAuthAppTestConsts.CollectionDefinitionName)]
public class Index_Tests : PasswordlessAuthAppWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
