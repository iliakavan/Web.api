using Webapi.Persistance;
using Webapi.Persistance.Repositories;
using Webapi.services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
{
    services.AddEndpointsApiExplorer();
    services.AddControllers();
    services.AddSwaggerGen();
    services.AddScoped<IProductRepository, ProductRepository>();
    services.AddScoped<IOrderRepository, OrderRepository>();
    services.AddScoped<IWareHouseRepository, WarehouseRepository>();
    services.AddScoped<IProductService, ProductService>();
    services.AddDbContext<AppDbContext>(p => p.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
}

// Configure the HTTP request pipeline.
var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}

