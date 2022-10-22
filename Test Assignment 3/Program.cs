using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Test_Assignment_3.Context;
using Test_Assignment_3.DataAccess;
using Test_Assignment_3.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var configuration = builder.Configuration;

builder.Services.AddScoped<IBookingStorage, BookingStorage>();
builder.Services.AddScoped<ICustomerStorage, CustomerStorage>();
builder.Services.AddScoped<IEmployeeStorage, EmployeeStorage>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddDbContext<DBApplicationContext>(options => 
options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

using (var scope = app.Services.CreateScope()) {
    var DB = scope.ServiceProvider.GetRequiredService<DBApplicationContext>();  
    DB.Database.Migrate();
    DB.Database.EnsureCreated();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
