using System.Reflection;
using EmartProd.Application.Interfaces;
using EmartProd.Infrastructure.EmartContext;
using EmartProd.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EmartProdContext>(opt=>{
    opt.UseSqlite(builder.Configuration.GetConnectionString("EmartProdConnection"));
});

builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
using var scope = app.Services.CreateScope();
var services= scope.ServiceProvider;
var context = services.GetRequiredService<EmartProdContext>();
var logger = services.GetRequiredService<ILogger<Program>>();
try
{
    await context.Database.MigrateAsync();
    await EmartProdContextSeed.SeedData(context);

}
catch (Exception ex)
{
    
    logger.LogError(ex,"An error while migration ");
}

app.Run();
