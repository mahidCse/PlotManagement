using Autofac;
using Microsoft.Extensions.Configuration;
using RealState.Core.Context;
using RealState.Core.Entity;
using RealState.Core.Repositories;
using RealState.Core.Services;
using RealState.Core.UnitOfWorks;
using System;


namespace RealState.Core
{
    public class CoreModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        private readonly IConfiguration _configuration;

        public CoreModule(IConfiguration configuration, string connectionStringName, string migrationAssemblyName)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString(connectionStringName);
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RealStateContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                   .InstancePerDependency();

            builder.RegisterType<RealStateContext>().As<IRealStateContext>()
                     .WithParameter("connectionString", _connectionString)
                     .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                     .InstancePerDependency();

            builder.RegisterType<RealStateUnitOfWork>().As<IRealStateUnitOfWork>()
                 .WithParameter("connectionString", _connectionString)
                 .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                 .InstancePerDependency();

            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>()
                .InstancePerDependency();

            builder.RegisterType<CustomerService>().As<ICustomerService>()
                .InstancePerDependency();

            builder.RegisterType<BlockRepository>().As<IBlockRepository>()
                .InstancePerDependency();

            builder.RegisterType<BlockService>().As<IBlockService>()
                .InstancePerDependency();

            builder.RegisterType<PlotRepository>().As<IPlotRepository>()
                .InstancePerDependency();

            builder.RegisterType<PlotService>().As<IPlotService>()
                .InstancePerDependency();

            builder.RegisterType<PlotBookingRepository>().As<IPlotBookingRepository>()
                .InstancePerDependency();
            builder.RegisterType<PlotBookingService>().As<IPlotBookingService>()
                .InstancePerDependency();

            builder.RegisterType<AccountRepository>().As<IAccountRepository>()
               .InstancePerDependency();
            builder.RegisterType<AccountService>().As<IAccountService>()
                .InstancePerDependency();

            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>()
               .InstancePerDependency();
            builder.RegisterType<CategoryService>().As<ICategoryService>()
                .InstancePerDependency();

            builder.RegisterType<TransactionRepository>().As<ITransactionRepository>()
               .InstancePerDependency();
            builder.RegisterType<TransactionService>().As<ITransactionService>()
                .InstancePerDependency();


            base.Load(builder);
        }
    }
}
