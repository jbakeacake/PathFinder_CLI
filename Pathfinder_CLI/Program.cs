using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pathfinder_CLI.Controllers;
using Pathfinder_CLI.Data;
using Pathfinder_CLI.Game.GameEntities.Characters;
using Pathfinder_CLI.Game.GameEntities.Items;
using Pathfinder_CLI.Helpers;

namespace Pathfinder_CLI
{
    class Program
    {
        static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        private IConfiguration _config;

        public async Task MainAsync()
        {
            _config = BuildConfig();

            var services = ConfigureServices();

            using (var scope = services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var context = serviceProvider.GetRequiredService<DataContext>();
                    context.Database.Migrate();
                    Seed.SeedData(context);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.ToString());
                }
            }
            Console.WriteLine("Tasks Completed");
            await Task.CompletedTask;
        }

        private IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton(_config)
                .AddAutoMapper(typeof(PathfinderRepository).Assembly)
                .AddDbContext<DataContext>(x => x.UseSqlite(_config.GetConnectionString("DefaultConnection")))
                .AddScoped<IPathfinderRepository, PathfinderRepository>()
                .AddScoped<ArmorController>()
                .AddScoped<CharacterController>()
                .AddScoped<PotionController>()
                .AddScoped<WeaponController>();
            
            return services.BuildServiceProvider();
        }

        private IConfiguration BuildConfig()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}
