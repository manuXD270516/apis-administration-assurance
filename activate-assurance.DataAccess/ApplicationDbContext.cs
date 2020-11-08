using activate_assurance.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace activate_assurance.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);


            builder.Entity<Product>()
                .Property(p => p.expirationDays)
                .HasDefaultValue(0);

            /*builder.Entity<Product>()
                .Property(p => p.createdAt)
                .HasDefaultValueSql("GETDATE()");

            builder.Entity<Product>()
                .Property(p => p.lastUpdated)
                .HasDefaultValueSql("GETDATE()");*/

            builder.Entity<Assurance>()
                .Property(p => p.activationDate)
                .HasDefaultValueSql("GETDATE()");

            builder.Entity<Assurance>()
                 .HasOne(e => e.usersCommerceActivate)
                 .WithMany(x => x.activateAssurances)
                 .HasForeignKey(e => e.usersCommerceActivateId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Assurance>()
                 .HasOne(e => e.usersCommerceClaim)
                 .WithMany(x => x.claimAssurances)
                 .HasForeignKey(e => e.usersCommerceClaimId)
                 .OnDelete(DeleteBehavior.Restrict);


            

        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            onBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            onBeforeSaving();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess,cancellationToken);
        }

        private void onBeforeSaving()
        {
            var entries = ChangeTracker.Entries();

            var datetimeNow = DateTime.Now;

            foreach (var entry in entries)
            {
                // for entities that inherit from BaseEntity,
                // set UpdatedOn / CreatedOn appropriately
                if (entry.Entity is BaseEntity trackable)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            // set the updated date to "now"
                            trackable.lastUpdated = datetimeNow;

                            // mark property as "don't touch"
                            // we don't want to update on a Modify operation
                            entry.Property("createdAt").IsModified = false;
                            break;

                        case EntityState.Added:
                            // set both updated and created date to "now"
                            trackable.createdAt = datetimeNow;
                            trackable.lastUpdated = datetimeNow;
                            break;
                    }
                }
            }
        }






        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients{ get; set; }
        public DbSet<Assurance> Assurances { get; set; }
        public DbSet<Commerce> Commerces{ get; set; }
        public DbSet<UsersCommerce> UsersCommerces { get; set; }

    }
}
