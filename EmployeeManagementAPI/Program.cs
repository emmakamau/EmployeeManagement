using EmployeeManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
builder.Services.AddDbContext<EManagementContext>(
    o => o.UseNpgsql(connectionString: builder.Configuration.GetConnectionString("EmployeeManagementDb")));

// Enable CORS
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// Json Serializer

builder.Services.AddControllersWithViews().AddNewtonsoftJson(options 
    => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
    .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//using (var scope = app.Services.CreateScope())
//{
//    var Services = scope.ServiceProvider;
//    var context = scope.ServiceProvider.GetService<EManagementContext>();
//    context.Database.Migrate();
//    SeedData.Initialize(context);
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

// Allow CORS
app.UseCors("AllowOrigin");
