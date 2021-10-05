﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
//using WazeCredit.Data.Repository;
//using WazeCredit.Data.Repository.IRepository;
using WazeCredit.Service;
using WazeCredit.Service.LifeTimeExample;

namespace WazeCredit.Utility.DI_Config
{
    public static class ConfigureDIServices
    {
        public static IServiceCollection AddAllServices(this IServiceCollection services)
        {
            services.AddTransient<IMarketForcaster, MarketForcasterV2>();           
            //services.TryAddTransient<IMarketForcaster, MarketForcaster>();  // Adds a 2nd implementation of IMarketForcaster.
            //services.Replace(ServiceDescriptor.Transient<IMarketForcaster, MarketForcasterV2>()); // Replaces the IMarketForcaster impl.
            //services.RemoveAll<IMarketForcaster>(); // Removes all IMarketForcaster impls.

            //services.TryAddEnumerable(new[] {
            //ServiceDescriptor.Scoped<IValidationChecker, AddressValidationChecker>(),
            //ServiceDescriptor.Scoped<IValidationChecker, CreditValidationChecker>()
            //});

            //services.AddScoped<ICreditValidator, CreditValidator>();

            services.AddTransient<TransientService>();
            services.AddScoped<ScopedService>();
            services.AddSingleton<SingletonService>();

            //services.AddSingleton<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<CreditApprovedHigh>();
            //services.AddScoped<CreditApprovedLow>();

            //services.AddScoped<Func<CreditApprovedEnum, ICreditApproved>>(ServiceProvider => range =>
            //{
            //    switch (range)
            //    {
            //        case CreditApprovedEnum.High: return ServiceProvider.GetService<CreditApprovedHigh>();
            //        case CreditApprovedEnum.Low: return ServiceProvider.GetService<CreditApprovedLow>();
            //        default: return ServiceProvider.GetService<CreditApprovedLow>();
            //    }
            //});

            ////services.AddSingleton<IMarketForecaster>(new MarketForecasterV2());
            ////services.AddTransient<MarketForecasterV2>();
            ////services.AddSingleton(new MarketForecasterV2());
            ////services.AddTransient(typeof(MarketForecasterV2));
            ////services.AddTransient(typeof(IMarketForecaster), typeof(MarketForecasterV2));
            ////services.AddScoped<IValidationChecker, AddressValidationChecker>();
            ////services.AddScoped<IValidationChecker, CreditValidationChecker>();
            ////services.TryAddEnumerable(ServiceDescriptor.Scoped<IValidationChecker, AddressValidationChecker>());
            ////services.TryAddEnumerable(ServiceDescriptor.Scoped<IValidationChecker, CreditValidationChecker>());


            //services.TryAddTransient<IMarketForecaster, MarketForecaster>();
            return services;
        }
    }
}
