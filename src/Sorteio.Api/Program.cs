using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Sorteio.Api.Configuracoes;
using Sorteio.Api.Data;
using Sorteio.Business.Interfaces.Base;
using Sorteio.Data.Context;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


//Auth services
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


//Deprecated
//builder.Services.AdicionarConfiguracaoJWT(builder.Configuration);

builder.Services.AddIdentityConfiguration(builder.Configuration);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("Total",
        builder =>
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
});

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
app.UseCors("Total");
app.MapControllers();

app.Run();
