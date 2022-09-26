using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebAPI.Persistence.Domains;

namespace WebAPI.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id)
               .HasMaxLength(50);
            builder.Property(p => p.Username)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasOne(d => d.UserDetail)
                .WithOne(ad => ad.User).HasForeignKey<UserDetail>(c => c.IdUser);

            builder.HasIndex(u => u.Username).IsUnique();
            builder.HasIndex(u => u.Email).IsUnique();
            //builder.HasIndex(u => new { u.Username, u.Email });


        }
    }
}
