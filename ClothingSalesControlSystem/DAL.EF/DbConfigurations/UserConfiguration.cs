using ClothingSalesControlSystem.Domain.Entities.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothingSalesControlSystem.DAL.EF.DbConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id); // Налаштування первинного ключа

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(100); // Налаштування властивості FirstName

            builder.Property(u => u.SecondName)
                .IsRequired()
                .HasMaxLength(100); // Налаштування властивості SecondName

            builder.Property(u => u.Email)
                .HasMaxLength(100); // Налаштування властивості Email

            builder.Property(u => u.Phone)
                .IsRequired()
                .HasMaxLength(25); // Налаштування властивості Phone

            builder.Property(u => u.Country)
                .IsRequired()
                .HasMaxLength(100); // Налаштування властивості Country

            builder.Property(u => u.City)
                .IsRequired()
                .HasMaxLength(100); // Налаштування властивості City

            builder.Property(u => u.Address)
                .IsRequired()
                .HasMaxLength(150); // Налаштування властивості Address

            builder.HasIndex(u => u.Email)
                .IsUnique(); // Додавання унікального індексу на властивість Email
            builder.HasIndex(u => u.Phone)
                .IsUnique(); ; // Додавання індексу на властивість Phone
        }
    }
}
