using ClothingSalesControlSystem.Domain.Entities.ClothingAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothingSalesControlSystem.DAL.EF.DbConfigurations
{
    public class TShirtConfiguration : IEntityTypeConfiguration<TShirt>
    {
        public void Configure(EntityTypeBuilder<TShirt> builder)
        {
            builder.HasKey(t => t.Id); // Налаштування первинного ключа

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(150); // Налаштування властивості Name

            builder.Property(t => t.Price)
                .IsRequired(); // Налаштування властивості Price

            builder.Property(t => t.Print)
                .HasMaxLength(150); // Налаштування властивості Print

            builder.Property(t => t.Size)
                .IsRequired()
                .HasMaxLength(50); // Налаштування властивості Size

            builder.Property(t => t.Color)
                .IsRequired()
                .HasMaxLength(150); // Налаштування властивості Color

            builder.Property(t => t.Material)
                .IsRequired()
                .HasMaxLength(100); // Налаштування властивості Material

            builder.Property(t => t.Type)
                .IsRequired(); // Налаштування властивості Type

            builder.HasIndex(t => t.Name)
                .IsUnique(); // Додавання унікального індексу на властивість Name
        }
    }
}
