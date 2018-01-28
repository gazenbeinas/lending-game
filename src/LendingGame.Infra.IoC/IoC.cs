using System;
using Microsoft.Extensions.DependencyInjection;

namespace LendingGame.Infra.IoC
{
    public class IoC
    {
        static IServiceCollection _serviceCollection;
        static IServiceProvider _serviceProvider;

        public static void SetServiceCollection(IServiceCollection serviceCollection) =>
            _serviceCollection = serviceCollection;

        public static void SetContainer(IServiceProvider serviceProvider) =>
            _serviceProvider = serviceProvider;

        public static void RegisterScoped<TInt, TImp>()
            where TInt : class
            where TImp : class, TInt =>
            _serviceCollection.AddScoped<TInt, TImp>();

        public static void RegisterTransient<TImp>()
            where TImp : class =>
            _serviceCollection.AddTransient<TImp>();

        public static void RegisterScoped<TService>()
            where TService : class =>
            _serviceCollection.AddScoped<TService>();

        public static TService Get<TService>() =>
            _serviceProvider.GetRequiredService<TService>();

        public static void RegisterModule<TModule>()
            where TModule : DependencyModule, new() =>
            new TModule().RegisterDependencies();

        public static void RegisterSingleton<TService>(TService service)
            where TService : class =>
            _serviceCollection.AddSingleton(service);
    }
}