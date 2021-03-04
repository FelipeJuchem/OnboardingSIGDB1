using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnboardingSIGDB1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OnboardingSIGDB1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Cargo> Cargo { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string environment = "Development";

            string settingsPath = Directory.GetCurrentDirectory();
            string settingsFile = "appsettings.json";
            string settingsFileEnv = $"appsettings.{environment}.json";

            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(settingsPath)
                .AddJsonFile(settingsFile, optional: false, reloadOnChange: true)
                .AddJsonFile(settingsFileEnv, optional: true)
                .AddEnvironmentVariables()
                .Build();

            var builder = new DbContextOptionsBuilder<DataContext>();

            optionsBuilder.UseSqlServer(configuration["ConnectionStrings:OnBoardingGlobal"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           

            var funcionario = modelBuilder.Entity<Funcionario>();

            funcionario.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(250);

            funcionario.Property(x => x.Id)
                 .IsRequired();


            funcionario.Property(x => x.Cpf)
                 .IsRequired();

            funcionario.Property(x => x.DataContratacao)
                 .IsRequired();

            var cargo = modelBuilder.Entity<Cargo>();

            cargo.Property(x => x.Descricao)
                .IsRequired()
                .HasMaxLength(250);

            cargo.Property(x => x.Id)
                 .IsRequired();
            
            var empresa = modelBuilder.Entity<Empresa>();

            empresa.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(250);

            empresa.Property(x => x.Id)
                 .IsRequired();


            empresa.Property(x => x.Cnpj)
                 .IsRequired();

            empresa.Property(x => x.DataFundacao)
                 .IsRequired();




        }


    }
}

