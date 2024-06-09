using api_booking_hotel.DBContext;
using api_booking_hotel.Repositories.AuthenRepositories;
using api_booking_hotel.Repositories.CategoryRepositories;
using api_booking_hotel.Repositories.FeatureRepositories;
using api_booking_hotel.Repositories.HotelRepositories;
using api_booking_hotel.Repositories.HotelReviewRepositories;
using api_booking_hotel.Repositories.HotelUtilityRepositories;
using api_booking_hotel.Repositories.ImageHotelRepositories;
using api_booking_hotel.Repositories.ImageRoomRepositories;
using api_booking_hotel.Repositories.RoomFeatureRepositories;
using api_booking_hotel.Repositories.RoomRepositories;
using api_booking_hotel.Repositories.UserRepositories;
using api_booking_hotel.Repositories.UtilityCategoryRepositories;
using api_booking_hotel.Repositories.UtilityRepositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MyDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();

builder.Services.AddScoped<IAuthenRepository, AuthenRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IImageHotelRepository, ImageHotelRepository>();
builder.Services.AddScoped<IUtilityCategoryRepository, UtilityCategoryRepository>();
builder.Services.AddScoped<IUtilityRepository, UtilityRepository>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IHotelUtilityRepository, HotelUtilityRepository>();
builder.Services.AddScoped<IFeatureRepository, FeatureRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IRoomFeatureRepository, RoomFeatureRepository>();
builder.Services.AddScoped<IImageRoomRepository, ImageRoomRepository>();
builder.Services.AddScoped<IHotelReviewRepository, HotelReviewRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
        {
            opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter token",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "bearer"
            });
            opt.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:SecretKey").Value!)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
builder.Services.AddCors(c => c.AddPolicy("AlowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
