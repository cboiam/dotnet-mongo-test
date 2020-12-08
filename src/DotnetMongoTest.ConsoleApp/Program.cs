using DotnetMongoTest.ConsoleApp.Interfaces;
using DotnetMongoTest.ConsoleApp.Menus;
using DotnetMongoTest.ConsoleApp.Operations;
using DotnetMongoTest.Infra;
using DotnetMongoTest.Infra.Interfaces;
using DotnetMongoTest.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetMongoTest.ConsoleApp
{
    internal sealed class Program
    {
        private static void Main()
        {
            var services = new ServiceCollection()
                .AddTransient<IMenu, Menu>()
                .AddTransient<IOperationFactory, OperationFactory>()
                .AddTransient<IMongoContext, MongoContext>()
                .AddTransient<IStudentRepository, StudentRepository>();
            
            var provider = services.BuildServiceProvider();
            
            provider.GetRequiredService<IMenu>().Render();
        }
    }
}
