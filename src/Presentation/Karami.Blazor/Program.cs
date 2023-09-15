using System.Reflection;
using BlazorState;
using Karami.Blazor.Frameworks.Extensions;
using Karami.Core.Infrastructure.Extensions;

/*-------------------------------------------------------------------*/

var builder = WebApplication.CreateBuilder(args);

#region Configs

builder.WebHost.ConfigureAppConfiguration((context, builder) => builder.AddJsonFiles(context.HostingEnvironment));

#endregion

/*-------------------------------------------------------------------*/

#region Service Container

builder.RegisterHelpers();
builder.RegisterCommandQueryUseCases();
builder.RegisterMessageBroker();
builder.RegisterServicesOfHttpWebRequest();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazorBootstrap();
builder.Services.AddBlazorState(
    options => options.Assemblies = new[] { typeof(Program).GetTypeInfo().Assembly }
);

#endregion

/*-------------------------------------------------------------------*/

var application = builder.Build();

/*-------------------------------------------------------------------*/

#region Middleware


if (application.Environment.IsProduction())
{
    application.UseHsts();
    application.UseHttpsRedirection();
}

application.UseStaticFiles();

application.UseRouting();

application.MapBlazorHub();

application.MapFallbackToPage("/_Host");

#endregion Middleware

/*-------------------------------------------------------------------*/

application.Run();

/*-------------------------------------------------------------------*/

//For Integration Test

public partial class Program {}