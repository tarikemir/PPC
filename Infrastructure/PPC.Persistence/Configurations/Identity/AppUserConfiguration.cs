using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PPC.Domain.Entities;
using PPC.Domain.Identity;

namespace PPC.Persistence.Configurations.Identity
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            // Configure one-to-many relationship between AppUser and Link
            builder.HasMany(u => u.Links)
                   .WithOne()
                   .HasForeignKey(link => link.UserId); // Assuming you have a UserId property in Link class to represent the foreign key
                                                        
            // Configure one-to-one relationship between AppUser and Wallet
            builder.HasOne(u => u.Wallet)
                   .WithOne(w => w.User)
                   .HasForeignKey<Wallet>(w => w.UserId);

            // Primary key
            builder.HasKey(u => u.Id);

            // Indexes for "normalized" username and email, to allow efficient lookups
            builder.HasIndex(u => u.NormalizedUserName).HasDatabaseName("UserNameIndex").IsUnique();
            builder.HasIndex(u => u.NormalizedEmail).HasDatabaseName("EmailIndex");

            // One to Many Relationship

            // A concurrency token for use with the optimistic concurrency checking
            builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            builder.Property(u => u.UserName).HasMaxLength(256);
            builder.Property(u => u.NormalizedUserName).HasMaxLength(256);
            builder.Property(u => u.Email).HasMaxLength(256);
            builder.Property(u => u.NormalizedEmail).HasMaxLength(256);

            // Name
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(70);

            // LastName
            builder.Property(x => x.Surname).IsRequired();
            builder.Property(x => x.Surname).HasMaxLength(70);

            // Gender
            builder.Property(x => x.Gender).IsRequired();
            builder.Property(x => x.Gender).HasConversion<int>();

            builder.Property(x => x.ProfilePicture).IsRequired(false);

            // CreatedByUserId
            builder.Property(x => x.CreatedByUserId).IsRequired();
            builder.Property(x => x.CreatedByUserId).HasMaxLength(75);

            // CreatedOn
            builder.Property(x => x.CreatedOn).IsRequired();

            // ModifiedByUserId
            builder.Property(x => x.ModifiedByUserId).IsRequired(false);
            builder.Property(x => x.ModifiedByUserId).HasMaxLength(75);

            // LastModifiedOn
            builder.Property(x => x.ModifiedOn).IsRequired(false);

            builder.ToTable("Users");
        }
    }
}
