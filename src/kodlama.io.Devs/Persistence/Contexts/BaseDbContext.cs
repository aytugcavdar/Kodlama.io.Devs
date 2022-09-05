using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BaseDbContext:DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgammingLanguages { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(p =>
            {
                p.ToTable("ProgammingLanguages").HasKey(k => k.Id);
                p.Property(k => k.Id).HasColumnName("Id");
                p.Property(K => K.Name).HasColumnName("Name");

            }) ;
            ProgrammingLanguage[] progammingLanguageEntitySeeds = { new(1, "C#") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(progammingLanguageEntitySeeds);
        }


    }
}
