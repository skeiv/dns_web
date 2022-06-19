using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using dns_web.Data;
using dns_web.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("dns_webContextConnection") ?? throw new InvalidOperationException("Connection string 'dns_webContextConnection' not found.");

builder.Services.AddDbContext<dns_webContext>(options =>
    options.UseSqlServer(connectionString));;

builder.Services.AddDefaultIdentity<dns_webUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<dns_webContext>();;

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
