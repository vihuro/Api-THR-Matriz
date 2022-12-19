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

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<UsuarioContext>(options =>
    options.UseNpgsql("Host=localhost;Port=5432;Pooling=true;DataBase=ApiDotNetTHR;User Id=postgres; Password = postgres"));

builder.Services.AddScoped<ILogin, LoginService>();
builder.Services.AddScoped<IClaims, ClaimsService>();
builder.Services.AddScoped<ICreateToken, CreateToken>();
builder.Services.AddScoped<IProdutosService, ProdutosService>();

var key = Encoding.ASCII.GetBytes("ajlKjLASJUISHIUO@2423");
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
        IssuerSigningKey = new SymmetricSecurityKey(key),
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
