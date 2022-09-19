using Domain.Entities;
using Kodlama.io.Core.Security.Entities;
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
        public DbSet<ProgrammingTechnology> ProgrammingTechnologies { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }


        public DbSet<GitHub> GitHubs { get; set; }




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
                p.HasMany(p => p.ProgrammingTechnologies);

            }) ;

            modelBuilder.Entity<ProgrammingTechnology>(p =>
            {
                p.ToTable("ProgrammingTechnologies").HasKey(k => k.Id);
                p.Property(k => k.Id).HasColumnName("Id");
                p.Property(K => K.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                p.Property(K => K.Name).HasColumnName("Name");
                p.Property(k => k.ImageUrl).HasColumnName("ImageUrl");
                p.HasOne(p => p.ProgrammingLanguage);

            });

            modelBuilder.Entity<User>(u =>
            {
                u.ToTable("Users").HasKey(k => k.Id);
                u.Property(p => p.Id).HasColumnName("Id");
                u.Property(p => p.FirstName).HasColumnName("FirstName");
                u.Property(p => p.LastName).HasColumnName("LastName");
                u.Property(p => p.Email).HasColumnName("Email");
                u.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
                u.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
                u.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(true);
                u.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");

                u.HasMany(p => p.UserOperationClaims);
                u.HasMany(p => p.RefreshTokens);
            });

            modelBuilder.Entity<UserOperationClaim>(u =>
            {
                u.ToTable("UserOperationClaims").HasKey(k => k.Id);
                u.Property(p => p.Id).HasColumnName("Id");
                u.Property(p => p.UserId).HasColumnName("UserId");
                u.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");
                u.HasOne(p => p.OperationClaim);
                u.HasOne(p => p.User);
            });

            modelBuilder.Entity<OperationClaim>(o =>
            {
                o.ToTable("OperationClaims").HasKey(k => k.Id);
                o.Property(p => p.Id).HasColumnName("Id");
                o.Property(p => p.Name).HasColumnName("Name");
            });

            modelBuilder.Entity<GitHub>(g =>
            {
                g.ToTable("GitHubs").HasKey(g => g.Id);
                g.Property(p => p.Id).HasColumnName("Id");
                g.Property(p => p.UserId).HasColumnName("UserId");
                g.Property(p => p.GitHubProfileLink).HasColumnName("GitHubProfileLink");
                g.HasOne(p => p.User);
            });

            OperationClaim[] operationClaimsEntitySeeds = {
                new(1, "Admin"),
                new(2, "User")
            };
            modelBuilder.Entity<OperationClaim>().HasData(operationClaimsEntitySeeds);










            ProgrammingLanguage[] progammingLanguageEntitySeeds = { new(1, "C#") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(progammingLanguageEntitySeeds);


            ProgrammingTechnology[] programmingTechnologiesEntitySeeds = { new(1,1, "WPF", ""), new(2, 1, "ASP.NET", ""), new(3, 3, "Spring", ""), new(4, 3, "JSP", "") };
            modelBuilder.Entity<ProgrammingTechnology>().HasData(programmingTechnologiesEntitySeeds);


        }


    }
}
