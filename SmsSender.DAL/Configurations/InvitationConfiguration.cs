using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmsSender.DAL.Entities;

namespace SmsSender.DAL.Configurations
{
    public class InvitationConfiguration : IEntityTypeConfiguration<Invitation>
    {
        public void Configure(EntityTypeBuilder<Invitation> builder)
        {
            builder.ToTable("Invitations");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Property(i => i.PhoneNumber).HasColumnName("Phone").HasMaxLength(11).IsRequired();
            builder.Property(i => i.AuthorId).HasColumnName("Author").IsRequired();
            builder.Property(i => i.CreationDate).HasColumnName("Createdon").ValueGeneratedOnAdd();

            builder.HasIndex(i => i.PhoneNumber).IsUnique();
        }
    }
}
