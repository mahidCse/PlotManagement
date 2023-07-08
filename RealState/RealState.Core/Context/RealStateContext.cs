using Microsoft.EntityFrameworkCore;
using RealState.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Core.Context
{
    public class RealStateContext :  DbContext , IRealStateContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Plot> Plots { get; set; }
        public DbSet<PlotBooking> PlotBookings { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public RealStateContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString, m => m.MigrationsAssembly(_migrationAssemblyName));
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Plot>()
                .HasOne(p => p.Block)
                .WithMany(b => b.Plots)
                .HasForeignKey(p => p.BlockId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PlotBooking>()
                .HasKey(pb => pb.Id);

            base.OnModelCreating(builder);
        }

        
    }
}
