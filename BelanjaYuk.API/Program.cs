using System.Text;
using Belanjayuk.API.Data;
using Belanjayuk.API.Helpers;
using Belanjayuk.API.Repositories;
using Belanjayuk.API.Repositories.Interfaces;
using Belanjayuk.API.Services;
using Belanjayuk.API.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<BelanjaYuk>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddSingleton<PasswordHelper>();
builder.Services.AddScoped<IUserPasswordRepository, UserPasswordRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISellerRepository, SellerRepository>();
builder.Services.AddScoped<ISellerService, SellerService>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IBuyerTransactionRepository, BuyerTransactionRepository>();
builder.Services.AddScoped<IBuyerTransactionService, BuyerTransactionService>();
builder.Services.AddScoped<IProductImageRepository, ProductImageRepository>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes("temporarily-secret-key-for-jwt-token-generation")),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.FromSeconds(30)
        };
    });

builder.Services.AddAuthorization();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();