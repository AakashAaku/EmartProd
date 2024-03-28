using EmartProd.API.Middleware;
using EmartProd.Infrastructure.EmartContext;
using Microsoft.EntityFrameworkCore;
using EmartProd.API.Extension;
using EmartProd.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.RegisterApplicationConfig();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddApplicationExtension(builder.Configuration);
var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
app.UseStatusCodePagesWithReExecute("/error/{0}");

// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
// }

//app.UseHttpsRedirection();

app.UseStaticFiles();
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
