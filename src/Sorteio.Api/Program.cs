using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Sorteio.Api.Configuracoes;
using Sorteio.Api.Data;
using Sorteio.Data.Context;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


//Auth services
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});



builder.Services.AdicionarConfiguracaoJWT(builder.Configuration);

// Add services to the container.


builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AdicionarConfiguracaoSwagger();

builder.Services.AddDbContext<SorteioDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.ResolverDependencias();

var app = builder.Build();

app.UsarConfiguracaoSwagger();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
