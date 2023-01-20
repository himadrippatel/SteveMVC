using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Steve.Model;

namespace Steve.Data
{
    public class UsersConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> entity)
        {
            entity.ToTable("tblUsers");

            entity.HasKey(t => t.Id);

            entity.Property(e => e.Name)
              .HasColumnType("nvarchar(100)");

            entity.Property(e => e.Password)
              .HasColumnType("nvarchar(100)");

            entity.Property(e => e.UserName)
              .HasColumnType("nvarchar(250)");

            entity.Property(e => e.MobileNumber)
              .HasColumnType("nvarchar(50)");

            entity.Property(e => e.EmailId)
              .HasColumnType("nvarchar(250)");

            entity.HasIndex(e => new { e.UserName, e.EmailId }).IsUnique(true);
        }
    }
}
