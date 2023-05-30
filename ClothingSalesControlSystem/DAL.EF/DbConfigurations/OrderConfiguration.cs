using ClothingSalesControlSystem.Domain.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothingSalesControlSystem.DAL.EF.DbConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id); // Налаштування первинного ключа

            builder.Property(o => o.OrderDate)
                .IsRequired()
                .HasDefaultValue(DateTime.Now);// Налаштування властивості OrderDate

            builder.Property(o => o.OrderPrice)
                .IsRequired(); // Налаштування властивості OrderPrice

            // Налаштування зовнішнього ключа для UserId
            builder.HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade); // Видалення замовлення при видаленні користувача

            // Налаштування зовнішнього ключа для TShirtId
            builder.HasOne(o => o.TShirt)
                .WithMany()
                .HasForeignKey(o => o.TShirtId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade); // Видалення замовлення при видаленні футболки

            builder.HasIndex(o => o.UserId); // Додавання індексу на властивість UserId
            builder.HasIndex(o => o.TShirtId); // Додавання індексу на властивість TShirtId
        }
    }
}
