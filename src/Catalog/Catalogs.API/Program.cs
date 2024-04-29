using Catalog.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("_myAllowSpecificOrigins",
        builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
});
builder.Services.AddDbContext<CatalogDbContext>(options =>
               options.UseNpgsql(builder.Configuration.GetConnectionString("CatalogConnectionString")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("_myAllowSpecificOrigins");
app.UseHttpsRedirection();
app.UseAuthorization();

app.UseAuthorization();

app.MapControllers();

app.Run();
