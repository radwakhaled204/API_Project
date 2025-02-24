
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using API_PRO.Data.Models;
using API_PRO.Mapping;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using API_PRO.Data;
using API_PRO.Extentions;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//1-add dataconnection
builder.Services.AddDbContext<AppDbContext>(Options =>
 Options.UseLazyLoadingProxies().UseSqlServer(
    builder.Configuration.GetConnectionString("myConnection")));


//2-add IDataRepository and DataRepository
builder.Services.AddScoped(typeof(IDataRepository<>), typeof(DataRepository<>));

//3-add IUnitOfWork and UnitOfWork
builder.Services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

//4-add AutoMapperProfile
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

//5-add Controllers
builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//6-add Endpoints
builder.Services.AddEndpointsApiExplorer();
//7-add jwt configrations
builder.Services.AddSwaggerGenJwtAuth();
builder.Services.AddCustomJwtAuth(builder.Configuration);

builder.Services.AddIdentity<Users, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (string.IsNullOrEmpty(app.Environment.WebRootPath))
{
    app.Environment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
}//==builder.WebHost.UseWebRoot("wwwroot");

// 
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();