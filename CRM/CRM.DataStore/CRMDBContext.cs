using System;
using CRM.Models.Dbo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CRM.DataStore
{
    public class CRMDBContext : IdentityDbContext<User,Role,long>
    {
        public CRMDBContext(DbContextOptions<CRMDBContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
            });

            builder.Entity<Role>(entity =>
            {
                entity.ToTable("Roles");
            });

            //   builder.Entity<UserRole>(entity =>
            // {
            //     entity.ToTable("UserRoles");
            // });

            // builder.Entity<UserLogin>(entity =>
            // {
            //     entity.ToTable("UserLogins");
            //     entity.HasKey(t=>t.)
            // });

            //  builder.Entity<UserClaim>(entity =>
            // {
            //     entity.ToTable("UserClaims");
            // });

            //  builder.Entity<RoleClaim>(entity =>
            // {
            //     entity.ToTable("RoleClaims");
            // });

            //  builder.Entity<UserToken>(entity =>
            // {
            //     entity.ToTable("UserTokens");
            // });

            builder.Entity<ContactActivity>(entity =>
            {
                entity.HasOne(t => t.ModifiedBy).WithMany(t => t.ModifiedContactActivities).
                HasForeignKey(t => t.ModifiedById).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.CreatedBy).WithMany(t => t.CreatedContactActivities).
                HasForeignKey(t => t.CreatedById).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.Contact).WithMany(t => t.ContactActivities).
                HasForeignKey(t => t.ContactId);
            });

            builder.Entity<Product>(entity =>
            {
                entity.HasOne(t => t.ModifiedBy).WithMany(t => t.ModifiedProducts).
                HasForeignKey(t => t.ModifiedById).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.CreatedBy).WithMany(t => t.CreatedProducts).
                HasForeignKey(t => t.CreatedById).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.User).WithMany(t => t.Products).
                HasForeignKey(t => t.UserId).OnDelete(DeleteBehavior.Restrict);

            
            });

            builder.Entity<OrganisationActivity>(entity =>
            {
                entity.HasOne(t => t.ModifiedBy).WithMany(t => t.ModifiedOrganisationActivities).
                HasForeignKey(t => t.ModifiedById).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.CreatedBy).WithMany(t => t.CreatedOrganisationActivities).
                HasForeignKey(t => t.CreatedById).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.Organisation).WithMany(t => t.OrganisationActivities).
                 HasForeignKey(t => t.OrganisationId);
            });

            builder.Entity<ContactAppointment>(entity =>
            {
                entity.HasOne(t => t.ModifiedBy).WithMany(t => t.ModifiedContactAppointments).
                HasForeignKey(t => t.ModifiedById).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.CreatedBy).WithMany(t => t.CreatedContactAppointments).
                HasForeignKey(t => t.CreatedById).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.Contact).WithMany(t => t.ContactAppointments).
                HasForeignKey(t => t.ContactId);
            });

            builder.Entity<OrganisationAppointment>(entity =>
            {
                entity.HasOne(t => t.ModifiedBy).WithMany(t => t.ModifiedOrganisationAppointments).
                HasForeignKey(t => t.ModifiedById).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.CreatedBy).WithMany(t => t.CreatedOrganisationAppointments).
                HasForeignKey(t => t.CreatedById).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.Organisation).WithMany(t => t.OrganisationAppointments).
                 HasForeignKey(t => t.OrganisationId);
            });

            builder.Entity<ContactNote>(entity =>
            {
                entity.HasOne(t => t.ModifiedBy).WithMany(t => t.ModifiedContactNotes).
                HasForeignKey(t => t.ModifiedById).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.CreatedBy).WithMany(t => t.CreatedContactNotes).
                HasForeignKey(t => t.CreatedById).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.Contact).WithMany(t => t.ContactNotes).
                HasForeignKey(t => t.ContactId);
            });

            builder.Entity<OrganisationNote>(entity =>
            {
                entity.HasOne(t => t.ModifiedBy).WithMany(t => t.ModifiedOrganisationNotes).
                HasForeignKey(t => t.ModifiedById).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.CreatedBy).WithMany(t => t.CreatedOrganisationNotes).
                HasForeignKey(t => t.CreatedById).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.Organisation).WithMany(t => t.OrganisationNotes).
                 HasForeignKey(t => t.OrganisationId);
            });


            builder.Entity<Order>(entity =>
           {
               entity.HasOne(t => t.ModifiedBy).WithMany(t => t.ModifiedOrders).
               HasForeignKey(t => t.ModifiedById).OnDelete(DeleteBehavior.Restrict);

               entity.HasOne(t => t.CreatedBy).WithMany(t => t.CreatedOrders).
               HasForeignKey(t => t.CreatedById).OnDelete(DeleteBehavior.Restrict);

           });

            builder.Entity<OrderItem>(entity =>
           {
               entity.HasOne(t => t.ModifiedBy).WithMany(t => t.ModifiedOrderItems).
               HasForeignKey(t => t.ModifiedById).OnDelete(DeleteBehavior.Restrict);

               entity.HasOne(t => t.CreatedBy).WithMany(t => t.CreatedOrderItems).
               HasForeignKey(t => t.CreatedById).OnDelete(DeleteBehavior.Restrict);


               entity.HasOne(t => t.Order).WithMany(t => t.OrderItems).
               HasForeignKey(t => t.OrderId);

               entity.HasOne(t => t.Product).WithMany(t => t.OrderItems).
               HasForeignKey(t => t.ProductId);

           });

            builder.Entity<Contact>(entity =>
            {
                entity.HasOne(t => t.ModifiedBy).WithMany(t => t.ModifiedContacts).
                HasForeignKey(t => t.ModifiedById).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.CreatedBy).WithMany(t => t.CreatedContacts).
                HasForeignKey(t => t.CreatedById).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.Organisation).WithMany(t => t.Contacts).
                HasForeignKey(t => t.OrganisationId);

                 entity.HasOne(t => t.User).WithMany(t => t.Contacts).
                HasForeignKey(t => t.UserId);

            });

            builder.Entity<Organisation>(entity =>
           {
               entity.HasOne(t => t.ModifiedBy).WithMany(t => t.ModifiedOrganisations).
               HasForeignKey(t => t.ModifiedById).OnDelete(DeleteBehavior.Restrict);

               entity.HasOne(t => t.CreatedBy).WithMany(t => t.CreatedOrganisations).
               HasForeignKey(t => t.CreatedById).OnDelete(DeleteBehavior.Restrict);

           });

            builder.Entity<Address>(entity =>
           {
               entity.HasOne(t => t.ModifiedBy).WithMany(t => t.ModifiedAddresses).
               HasForeignKey(t => t.ModifiedById).OnDelete(DeleteBehavior.Restrict);

               entity.HasOne(t => t.CreatedBy).WithMany(t => t.CreatedAddresses).
               HasForeignKey(t => t.CreatedById).OnDelete(DeleteBehavior.Restrict);

               entity.HasOne(t => t.ContactAddress).WithOne(t => t.Address).
             HasForeignKey<ContactAddress>(t => t.AddressId);

               entity.HasOne(t => t.OrganisationAddress).WithOne(t => t.Address).
                HasForeignKey<OrganisationAddress>(t => t.AddressId);

           });

            builder.Entity<OrganisationAddress>(entity =>
           {
               entity.HasOne(t => t.Organisation).WithMany(t => t.Addresses).
               HasForeignKey(t => t.OrganisationId);

           });


            builder.Entity<ContactAddress>(entity =>
          {
              entity.HasOne(t => t.Contact).WithMany(t => t.Addresses).
              HasForeignKey(t => t.ContactId);

          });


 base.OnModelCreating(builder);
        }

    
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Organisation> Organisations { get; set; }

        public DbSet<Address> Addresses { get; set; }

         public DbSet<ContactAddress> ContactAddresses { get; set; }

          public DbSet<OrganisationAddress> OrganisationAddresses { get; set; }



        public DbSet<ContactActivity> ContactActivities { get; set; }

        public DbSet<OrganisationActivity> OrganisationActivities { get; set; }


        public DbSet<ContactAppointment> ContactAppointments { get; set; }

        public DbSet<OrganisationAppointment> OrganisationAppointments { get; set; }

        // public DbSet<Note> Notes { get; set; }

        public DbSet<ContactNote> ContactNotes { get; set; }

        public DbSet<OrganisationNote> OrganisationNotes { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Product> Products { get; set; }

    }
}
