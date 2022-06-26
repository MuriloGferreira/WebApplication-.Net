using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Repository.Context
{
    public class AplicationDbContext:DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }

        public AplicationDbContext(DbContextOptions<AplicationDbContext> Options):base(Options) 
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
