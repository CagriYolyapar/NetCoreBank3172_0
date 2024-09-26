using Microsoft.EntityFrameworkCore;
using NetCoreBank3172_0.Models.ContextClasses;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<MyContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));


builder.Services.AddCors(cors =>
{
    cors.AddPolicy("YZL3172",opt =>
    {
        opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("YZL3172");

app.UseAuthorization();

app.MapControllers();

app.Run();
