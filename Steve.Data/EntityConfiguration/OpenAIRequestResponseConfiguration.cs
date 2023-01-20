using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Steve.Model;

namespace Steve.Data
{
    public class OpenAIRequestResponseConfiguration : IEntityTypeConfiguration<OpenAIRequestResponse>
    {
        public void Configure(EntityTypeBuilder<OpenAIRequestResponse> entity)
        {
            entity.ToTable("tblOpenAIRequestResponse");

            entity.HasKey("Id");

            entity.Property(e => e.UserId);

            entity.Property(e => e.Type)
                .IsRequired()
                .HasConversion(new EnumToStringConverter<EnumOpenaiType>())
                .HasColumnType("nvarchar(100)");

            entity.HasOne(e => e.User)
            .WithMany(e => e.OpenAIRequestResponses)
            .HasForeignKey(e => new
            {
                e.UserId
            }).HasConstraintName("FK_tblOpenAIRequestResponse_tblUsers_UserID");
            
        }
    }
}
