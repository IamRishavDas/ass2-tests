using Microsoft.AspNetCore.Builder;
using PasswordlessAuthApp;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("PasswordlessAuthApp.Web.csproj"); 
await builder.RunAbpModuleAsync<PasswordlessAuthAppWebTestModule>(applicationName: "PasswordlessAuthApp.Web");

public partial class Program
{
}
