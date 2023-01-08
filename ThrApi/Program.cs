using ThrApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ThrApi.Interface.Login;
using ThrApi.Service.Login;
using ThrApi.Service.JWT;
using ThrApi.Interface.Estoque;
using ThrApi.Service.Estoque;
using ThrApi.Settings;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("SistemaTHR");

builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<UsuarioContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<EstoqueContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<ILogin, LoginService>();
builder.Services.AddScoped<IClaims, ClaimsService>();
builder.Services.AddScoped<ICreateToken, CreateToken>();
builder.Services.AddScoped<IProdutosService, ProdutosService>();

//JWT

var appSettingSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingSection);

var appSettings = appSettingSection.Get<AppSettings>();

var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(appSettings.Secret));

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = key,
        ValidateIssuer = false,
        ValidateAudience = false

    };
});



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseHttpsRedirection();
builder.Services.AddCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
