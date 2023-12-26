using EfSchemaProblem.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddDbContext<ContextA>(options =>
    {
        options.UseNpgsql("Host=localhost;Port=5432;Database=EFTest.Identity;Username=postgres;Password=postgres");
        options.LogTo(Console.WriteLine);
    })
    .AddDbContext<ContextB>(options =>
    {
        options.UseNpgsql("Host=localhost;Port=5432;Database=EfTest.Files;Username=postgres;Password=postgres");
        options.LogTo(Console.WriteLine);
    });

var serviceProvider = services.BuildServiceProvider();

await serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ContextA>().Database.MigrateAsync();

var contextA = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ContextA>();
var contextB = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ContextB>();
