using Microsoft.EntityFrameworkCore;
using SelfieAWookies.Core.Selfies.Domain;
using SelfieAWookies.Core.Selfies.Infrastructures.Data;
using SelfieAWookies.Core.Selfies.Infrastructures.Repositories;
using SelfieAWookie.API.UI.ExtensionMethods;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddDbContext<SelfiesContext>(options =>
//{
//options.UseSqlServer(builder.Configuration.GetConnectionString("SelfiesDatabase"), sqlOptions => {});
//});

//builder.Services.AddDbContext<SelfiesContext>(Options =>
//{
//    Options.UseSqlServer(configuration)
//});

builder.Services.AddDbContext<SelfiesContext>(Options => Options.UseSqlServer(builder.Configuration.GetValue<string>("SelfiesDataBase")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{

}).AddEntityFrameworkStores<SelfiesContext>();


builder.Services.AddCustomOption(builder.Configuration);
builder.Services.AddInjections();
builder.Services.AddCustomSecurity(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{   

}

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


//app.UseRouting();
app.UseCors(SecurityMethods.DEFAULT_POLICY_2);

app.MapControllers();

app.Run();
