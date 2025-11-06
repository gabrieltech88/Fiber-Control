using Microsoft.EntityFrameworkCore;

using FiberControlApi.Data;
using FiberControlApi.Data.Dal;
using FiberControlApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontEnd", policy =>
    {
        policy.WithOrigins("http://127.0.0.1:5500") // ou "*", se quiser permitir qualquer origem (não recomendado em produção)
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var connectionString = builder.Configuration["ConnectionString"];



builder.Services.AddDbContext<FiberControlContext>(opts => opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<OltService>();
builder.Services.AddScoped<OltDAL>();
builder.Services.AddControllers();

var app = builder.Build();

app.UseCors("PermitirFrontEnd");
app.UseRouting(); 
app.UseHttpsRedirection();
app.MapControllers();

app.MapGet("/", () => "API FiberControl rodando com sucesso 🚀");

app.Run(); 
