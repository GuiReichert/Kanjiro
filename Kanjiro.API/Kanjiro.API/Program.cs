using Kanjiro.API.Database;
using Kanjiro.API.Services;
using Kanjiro.API.Services.Interfaces;
using Kanjiro.API.Utils.Handlers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Kanjiro_Context>(
                            x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")),
                            contextLifetime: ServiceLifetime.Scoped,
                            optionsLifetime: ServiceLifetime.Singleton);
builder.Services.AddDbContextFactory<Kanjiro_Context>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IDeckService, DeckService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICardInfoService, CardInfoService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IPlacementTestService, PlacementTestService>();


var app = builder.Build();

LogHandler.Configure(app.Services.GetRequiredService<IDbContextFactory<Kanjiro_Context>>());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#if !DEBUG
app.UseHttpsRedirection();
#endif

app.UseAuthorization();

app.MapControllers();

app.Run();
