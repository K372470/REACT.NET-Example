using DriveHack.Site.Models;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using JavaScriptEngineSwitcher.V8;
using Microsoft.EntityFrameworkCore;
using React.AspNet;
using System.Net;


var builder = WebApplication.CreateBuilder();
#region  Services
builder.Services
    .AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
    .AddReact()
    .AddJsEngineSwitcher(options => options.DefaultEngineName = V8JsEngine.EngineName).AddV8();

builder.Services.AddControllersWithViews(x => x.EnableEndpointRouting = false);
builder.Services.AddDbContext<ApplicationContext>(optons => optons.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=applicationdb;Trusted_Connection=True;"));
builder.Services.AddControllersWithViews().AddNewtonsoftJson();
#endregion

#region Kestrel
builder.WebHost.UseKestrel(options =>
{
    var address = Dns.GetHostAddresses(Dns.GetHostName(), System.Net.Sockets.AddressFamily.InterNetwork).First();
    options.Listen(address, 5000);
    options.Listen(address, 5001, listenOptions =>
  {
      listenOptions.UseHttps();
      listenOptions.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http1;
  });
});
#endregion

#region Middlewares to use something (idk how to rename this actually)
var app = builder.Build();
app.UseHsts();
app.UseReact(x =>
    x.SetLoadBabel(false)
    .SetLoadReact(false)
    .AddScriptWithoutTransform("~/dist/main.js")
    .AddScriptWithoutTransform("~/dist/runtime.js")
    .AddScriptWithoutTransform("~/dist/vendor.js"));
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseMvc();
#endregion
await app.RunAsync();