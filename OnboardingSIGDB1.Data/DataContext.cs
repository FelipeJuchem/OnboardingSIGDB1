﻿using Microsoft.EntityFrameworkCore;
using OnboardingSIGDB1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite(@"Server=(localdb)\mssqllocaldb;Database=Test");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var empresa = modelBuilder.Entity<Empresa>();

            empresa.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(250);

            empresa.Property(tc => tc.Id)
                 .IsRequired();


            empresa.Property(tc => tc.Cnpj)
                 .IsRequired();

            empresa.Property(tc => tc.DataFundacao)
                 .IsRequired();









        }


    }
}
