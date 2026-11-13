using PizzariaAPI.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<PizzariaContext>(options =>

        options.UseSqlServer(builder.Configuration.GetConnectionString("Pizzaria"))
);

builder.Services.AddScoped<PizzariaContext>();


var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/api/pizzas", (PizzariaContext db) => db.Pizza.ToList());

app.Run();
